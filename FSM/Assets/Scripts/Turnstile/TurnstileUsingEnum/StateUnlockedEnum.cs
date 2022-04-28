using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMAI;
public class StateUnlockedEnum : State<TurnstileStates>
{
  // We have now implemented a autolock system.
  // The autolock activates after 10 seconds.
  FSM<TurnstileStates> mFsm;
  float mStartTime = 0.0f;
  float LockTimer = 10.0f;

  TurnstileUsingEnum mTurnstile;
  public StateUnlockedEnum(TurnstileStates name)
    : base(name)
  {

  }
  public StateUnlockedEnum(TurnstileStates name, FSM<TurnstileStates> fsm)
    : base(name)
  {
    mFsm = fsm;
  }
  public StateUnlockedEnum(TurnstileStates name, FSM<TurnstileStates> fsm, TurnstileUsingEnum turnstile)
    : base(name)
  {
    mFsm = fsm;
    mTurnstile = turnstile;
  }

  public void SetTurnstile(TurnstileUsingEnum turnstile)
  {
    mTurnstile = turnstile;
  }

  public override void Enter()
  {
    base.Enter();
    Debug.Log(Name + " - UnLocked State is activated! You can now pass through the gate.");

    mStartTime = Time.time;
    mTurnstile.StartCountdownTimer(LockTimer);
  }

  public override void Exit()
  {
    base.Exit();
    Debug.Log(Name + " - UnLocked State is deactivated!");
  }

  public override void Update()
  {
    base.Update();

    if (Input.GetKeyDown("p"))
    {
      // the user has inserted a coin.
      // Play the coin drop sound.
      // Transition to the next state?
      mTurnstile.StopCountdownTimer();
      mFsm.SetCurrentState(TurnstileStates.LOCKED);
    }
    float currTime = Time.time;
    float deltaTime = currTime - mStartTime;

    if (deltaTime >= LockTimer)
    {
      mTurnstile.StopCountdownTimer();
      mFsm.SetCurrentState(TurnstileStates.LOCKED);
    }
  }
}

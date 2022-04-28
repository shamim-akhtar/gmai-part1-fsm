using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMAI;
public class StateUnlocked : State<string>
{
  // We have now implemented a autolock system.
  // The autolock activates after 10 seconds.
  FSM<string> mFsm;
  float mStartTime = 0.0f;
  float LockTimer = 10.0f;

  Turnstile mTurnstile;
  public StateUnlocked(string name)
    : base(name)
  {

  }
  public StateUnlocked(string name, FSM<string> fsm)
    : base(name)
  {
    mFsm = fsm;
  }
  public StateUnlocked(string name, FSM<string> fsm, Turnstile turnstile)
    : base(name)
  {
    mFsm = fsm;
    mTurnstile = turnstile;
  }

  public void SetTurnstile(Turnstile turnstile)
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
      mFsm.SetCurrentState("locked");
    }
    float currTime = Time.time;
    float deltaTime = currTime - mStartTime;

    if (deltaTime >= LockTimer)
    {
      mTurnstile.StopCountdownTimer();
      mFsm.SetCurrentState("locked");
    }
  }
}

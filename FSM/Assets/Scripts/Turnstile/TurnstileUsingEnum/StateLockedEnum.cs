using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMAI;

public class StateLockedEnum : State<TurnstileStates>
{
  FSM<TurnstileStates> mFsm;
  public StateLockedEnum(TurnstileStates name)
    : base(name)
  {

  }
  public StateLockedEnum(TurnstileStates name, FSM<TurnstileStates> fsm)
    : base(name)
  {
    mFsm = fsm;
  }

  public override void Enter()
  {
    base.Enter();
    Debug.Log(Name + " - Locked State is activated! Please insert a coin to Unlock.");
    // Play the audio.
  }

  public override void Exit()
  {
    base.Exit();
    Debug.Log(Name + " - Locked State is deactivated.");
  }

  public override void Update()
  {
    base.Update();
    if (Input.GetKeyDown("c"))
    {
      // the user has inserted a coin.
      // Play the coin drop sound.
      // Transition to the next state?
      mFsm.SetCurrentState(TurnstileStates.UNLOCKED);
    }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMAI;

public class StateLocked : State<string>
{
  FSM<string> mFsm;
  public StateLocked(string name)
    : base(name)
  {

  }
  public StateLocked(string name, FSM<string> fsm)
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
      mFsm.SetCurrentState("unlocked");
    }
  }
}

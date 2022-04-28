using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMAI;

public class Turnstile : MonoBehaviour
{
  string mLockedStateName = "locked";
  string mUnlockedStateName = "unlocked";

  #region Private variables
  FSM<string> mFsm = new FSM<string>();
  IEnumerator mTimer = null;
  private float mStartTime = 0.0f;
  #endregion

  #region Private functions

  // Start is called before the first frame update
  void Start()
  {
    //mFsm.AddState(mLockedStateName, new LockedState(mLockedStateName));
    mFsm.AddState(new StateLocked(mLockedStateName, mFsm));
    mFsm.AddState(new StateUnlocked(mUnlockedStateName, mFsm, this));
    mFsm.SetCurrentState("locked");
  }

  // Update is called once per frame
  void Update()
  {
    mFsm.Update();
  }
  private IEnumerator CountdownTimer_Coroutine(float duration)
  {
    mStartTime = Time.time;
    float index = duration;
    float deltaTime = Time.time - mStartTime;
    while (deltaTime <= duration)
    {
      index -= 1.0f;
      Debug.Log("Time: " + index);
      yield return new WaitForSeconds(1.0f);
      deltaTime = Time.time - mStartTime;
    }
  }
  #endregion

  #region Public Functions
  public void StartCountdownTimer(float duration)
  {
    mTimer = CountdownTimer_Coroutine(duration);
    StartCoroutine(mTimer);
  }

  public void StopCountdownTimer()
  {
    if(mTimer != null)
    {
      StopCoroutine(mTimer);
      mTimer = null;
    }
  }
  #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMAI;

public enum TurnstileStates
{
  LOCKED,
  UNLOCKED,
}
public class TurnstileUsingEnum : MonoBehaviour
{

  FSM<TurnstileStates> mFsm = new FSM<TurnstileStates>();

  #region Private variables
  IEnumerator mTimer = null;
  private float mStartTime = 0.0f;
  #endregion

  // Start is called before the first frame update
  void Start()
  {
    mFsm.AddState(new StateLockedEnum(TurnstileStates.LOCKED, mFsm));
    mFsm.AddState(new StateUnlockedEnum(TurnstileStates.UNLOCKED, mFsm, this));
    mFsm.SetCurrentState(TurnstileStates.LOCKED);

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

  #region Public Functions
  public void StartCountdownTimer(float duration)
  {
    mTimer = CountdownTimer_Coroutine(duration);
    StartCoroutine(mTimer);
  }

  public void StopCountdownTimer()
  {
    if (mTimer != null)
    {
      StopCoroutine(mTimer);
      mTimer = null;
    }
  }
  #endregion

}

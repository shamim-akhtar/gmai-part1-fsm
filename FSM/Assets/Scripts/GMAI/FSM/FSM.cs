using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region My comments and inputs for the lesson.
// TODO: 
// 1. Understand the Finite State Machine (FSM) - Recap - done
// 2. Implement a class based FSM - done
// 3. Apply the FSM to either the Turnstile or the Traffic Light - done


// 4. Refactor our code to make it better. 
// Remember: Refactoring is not enhancing the functionality but to 
// make your code more readable, robust, maintainable etc.
// Also remember that refacoring is not a one time job. Refactoring has to be
// continuous, until the point you find that your codes are stable and
// do not need any further refactoring.
// 5. Finally, after refactoring we willl create a Generic FSM.
//
// 6. Again a recap on
//  a. The assignment 1,
//  b. The Quiz
//  c. Remind you to submit your worksheet.
//  d. Provide you with the references that you can use to enhance your understanding of the FSM.


/// <summary>
/// What is an FSM?
/// The FMS is a computational pattern (design pattern).
/// FMS defines the state behaviour of a system (in sofwtare 
/// terms a system is just the application).
/// Definition: An FSM comprises a number of states and at any given point in time
/// only one of these possible states is active.
/// </summary>

// Lets put a namespace called GMAI to put all
// our classes that we will create in our GMAI subject run.
#endregion

namespace GMAI
{
  /// <summary>
  /// FSM class. 
  /// This class implements a simple class based Finite State Machine.What is an FSM?
  /// The FMS is a computational pattern (design pattern).
  /// FMS defines the state behaviour of a system (in sofwtare 
  /// terms a system is just the application).
  /// Definition: An FSM comprises a number of states and at any given point in time
  /// only one of these possible states is active.
  /// </summary>
  public class FSM<T>
  {
    #region Private variables
    // We need to have all the states for this FSM.
    // How do we keep the set of states? List, Dictionary? How?
    //List<State> mStates = new List<State>();
    // Why did we choose dictionary? 
    // So that we can cache the state with a name.
    // 
    Dictionary<T, State<T>> mStates = new Dictionary<T, State<T>>();
    State<T> mCurrentState = null;
    #endregion

    #region Private functions
    private void SetCurrentState(State<T> state)
    {
      if(mCurrentState != null)
      {
        // my current state is valid. So I think it better to inform
        // this current state that you are exiting.
        mCurrentState.Exit();
      }
      // Can we directly set the state to current state?
      mCurrentState = state;

      // since there is a change in current state, so I think it is better
      // to inform the new current that you are Enter.
      if(mCurrentState != null)
      {
        mCurrentState.Enter();
      }
    }
    #endregion

    #region Public functions
    /// <summary>
    /// AddState allows the caller of the function to
    /// add a state into the finite state machine.
    /// Ensure that the state is not null.
    /// </summary>
    /// <param name="name">The name of the State</param>
    /// <param name="state">The reference to the State</param>
    public void AddState(T id, State<T> state)
    {
      mStates.Add(id, state);
    }
    /// <summary>
    /// AddState allows the caller of the function to
    /// add a state into the finite state machine.
    /// Ensure that the state is not null.
    /// </summary>
    /// <param name="state">The reference to the State</param>
    public void AddState(State<T> state)
    {
      mStates.Add(state.mID, state);
    }

    public State<T> GetState(T id)
    {
      if (mStates.ContainsKey(id))
      {
        return mStates[id];
      }
      return null;
    }

    public State<T> GetCurrentState()
    {
      return mCurrentState;
    }

    /// <summary>
    /// This function allows the caller to set the current state of the
    /// finite state machine. 
    /// In this function instead of directly setting the new state to the current state
    /// we first call the Exit method the old state and then call the Enter method
    /// of the new State.
    /// </summary>
    /// <param name="name"></param>
    public void SetCurrentState(T id)
    {
      if (mStates.ContainsKey(id))
      {
        State<T> state = mStates[id];
        if (state != null)
        {
          SetCurrentState(state);
        }
      }
    }
    /// <summary>
    /// This method allows the finite state machine's current state
    /// to tick every frame. This method also allows the caller to sync
    /// their Unity application with the current state's tick. Preferably
    /// call this method from Unity's Update method.
    /// </summary>
    public void Update()
    {
      if(mCurrentState != null)
      {
        mCurrentState.Update();
      }
    }
    #endregion
  }
}

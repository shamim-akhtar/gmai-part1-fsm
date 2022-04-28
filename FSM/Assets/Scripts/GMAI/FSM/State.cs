using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMAI
{
  // The first code that we write is a State.
  // What is a state? We dont know yet.
  // lets create an empty class called State.
  public class State<T>
  {
    string mName;
    public T mID 
    { 
      get; 
      private set; 
    }

    public string Name
    {
      get
      {
        return mName;
      }
    }
    public State(T id)
    {
      mName = "";
      mID = id;
    }
    public State(T id, string name)
    {
      mName = name;
      mID = id;
    }

    public virtual void Enter()
    {
    }
    public virtual void Exit()
    {
    }
    public virtual void Update()
    {

    }
  }
}

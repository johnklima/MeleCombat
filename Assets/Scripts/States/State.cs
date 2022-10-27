using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is the non - concrete state that all other states inherit from
public abstract class State : MonoBehaviour
{
    //am I actually in this state
    public bool isInState;
    
    //for debugging to help sort what's going on
    public string stateName = "base";

    public virtual bool processState(Transform owner)
    {
              

        //all states will process child states first
        foreach (Transform child in transform)
        {
            State state = child.GetComponent<State>();
            bool teststate = state.processState(owner);
            if (teststate)
            {
                isInState = false;
                return teststate;
            }                
           
        }

        //abstract returns default false, overriden by the concrete class.
        isInState = false;
        return isInState;
    
    }


}

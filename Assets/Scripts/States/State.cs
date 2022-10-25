using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is the non - concrete state that all other states inherit from
public abstract class State : MonoBehaviour
{
    //am I actually in this state
    public bool isInState = false;
    
    //for debugging to help sort what going on
    public string stateName = "base";

    public virtual bool processState(Transform owner)
    {

        //all states will process child states first
        foreach (Transform child in transform)
        {
            State state = child.GetComponent<State>();
            if (state.processState(owner))
            {
                Debug.Log("State Name True " + stateName);
                return true;
            }                
            else
                return false;
        }

        return false;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override bool processState(Transform owner)
    { 
        if(base.processState(owner))
        {
            Debug.Log("Idle says a child is true");
            isInState = false;
            return isInState;
        }

        isInState = true;
        return isInState;
    }
}

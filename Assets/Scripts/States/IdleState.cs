using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override bool processState(Transform owner)
    {
        bool testchild = base.processState(owner);
        if(testchild)
        {            
            isInState = false;
            return testchild;
        }

        //if nothing else is true, idle must be
        isInState = true;
        return isInState;
    }
}

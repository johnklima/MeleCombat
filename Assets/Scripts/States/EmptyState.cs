using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyState : State
{
    public override bool processState(Transform owner)
    {

        base.processState(owner);

        //a null node in the state that always returns false
        //but processes children, to enable state groups
        return false;

    }
}

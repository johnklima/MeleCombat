using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerState : State
{

    public VizCone enemyCone;

    public override bool processState(Transform owner)
    {
         
        bool testchild = base.processState(owner);

        if (testchild)
        {
            isInState = false;
            return testchild;
        }

          //start by saying false
        isInState = false;

        if (enemyCone.target == null)
            return isInState;

        if(Vector3.Distance(enemyCone.target.transform.position, owner.transform.position ) < 2.5f)
        {
            Debug.Log("DO ATTACK");
            isInState = true;
        }

        return isInState;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{

    public VizCone enemyCone;          // the VizCone component of the cone geometry belonging to this character
    public WeaponState defaultWeapon;  
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

        if(Vector3.Distance(enemyCone.target.transform.position, owner.transform.position ) < 2.5f) // based on stopping distance
        {
            if (!defaultWeapon.allowState)
            {
                Debug.Log("DO ATTACK");
                defaultWeapon.allowStateAndChildren(true);  //allow our weapons to actually process                
                isInState = true;                           //only really happens once or twice, thereafter the weapons are true
                                                            //only a small chance weapons wont occur the first process
            }

        }
        else
            defaultWeapon.allowStateAndChildren(false);     //disallow if not in position

        return isInState;
        
    }
}

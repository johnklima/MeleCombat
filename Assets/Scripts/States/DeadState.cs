using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool processState(Transform owner)
    {

        bool testchild = false;

        testchild = base.processState(owner);

        if (testchild)
        {
            isInState = false;
            return testchild;
        }
                
        if (isInState)
            Debug.Log("processed INHERITED state " + stateName + " owner " + owner.name + " return " + isInState);
        else
            Debug.Log("processed INHERITED state Not Dead");

        return isInState;
    }
}

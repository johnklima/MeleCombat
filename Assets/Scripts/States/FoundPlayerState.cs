using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundPlayerState : State
{

    private VizCone cone;
    // Start is called before the first frame update
    void Start()
    {
        //get THIS NPCs vizcone
        cone = GetComponent<VizCone>();
       
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

        isInState = false;
        
        if(cone.playerIsVisible)
        {
            cone.navigation.target = cone.target ;
            isInState = true;
        }
                

        return isInState;
    }
}

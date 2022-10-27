using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{

    public Transform patrolPoints;
    private int curPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    public override bool processState(Transform owner) 
    {
        bool testchild = base.processState(owner);

        if (testchild)
        {
            isInState = false;
            return testchild;
        }

        //no overriding states are true, so do me regardless
        //patrol is the default fallback state, perhaps to be
        //triggered by some desire or order to override idle,
        //but for this demo, patrol is the root state
        isInState = true;

        //imagine this as the Update method
        Navigation nav = owner.GetComponent<Navigation>();
        NavMeshAgent agent = owner.GetComponent<NavMeshAgent>();
        
        if(agent.remainingDistance < 2.3f && agent.remainingDistance > 0)
        {
            curPoint++;
            if (curPoint == patrolPoints.childCount)
                curPoint = 0;

        }

        nav.target = patrolPoints.GetChild(curPoint);
        
        return isInState;
    }
}

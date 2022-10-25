using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{

    public Transform patrolPoints;
    private int curPoint = -1;

    // Start is called before the first frame update
    void Start()
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

        //no overriding states are true, so do me regardless
        isInState = true;

        //imagine this as the Update method
        Navigation nav = owner.GetComponent<Navigation>();
        NavMeshAgent agent = owner.GetComponent<NavMeshAgent>();
        
        if(agent.remainingDistance < 2.3f )
        {
            curPoint++;
            if (curPoint == patrolPoints.childCount)
                curPoint = 0;

        }

        nav.target = patrolPoints.GetChild(curPoint);
        
        return isInState;
    }
}

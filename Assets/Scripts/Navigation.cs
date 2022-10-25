using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{

    public Transform target; //this can be anything in the game

    private NavMeshAgent agent = null;      //NPC's nav agent
    
    // Start is called before the first frame update
    void Start()
    {
        //get the agent component 
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //if I have a target, set it as my destination
        if(target)
        {
            agent.SetDestination(target.position);
        }
    }
}

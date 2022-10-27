using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTree : MonoBehaviour
{

    public Transform owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        foreach (Transform child in transform)
        {
            bool testchild = child.GetComponent<State>().processState(owner);
            if (testchild)
            {
                //this is here to basically handle dead state, or any situation where we have multiple
                //branches at the top of the state tree. Dead would be the most common occurance.
                return;
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VizCone : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform owner;     //owner of the visibility cone
    public Transform target;    //specific target I am looking for

    private Navigation navtarget;  //owner's navigation component to set NavAgentDestination

    void Start()
    {
        navtarget = owner.GetComponent<Navigation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        

        if (other.transform == target)
        {
            Debug.Log("NPC cones " + target.name);

            // Bit shift the index of the layer (7) to get a bit mask
            int layerMask = 1 << 7;  //which is the viz obstacles layer            

            RaycastHit hit;

            //direction is "destination" minus "source"
            Vector3 direction =  target.position - owner.position;

            direction.Normalize();

            // Does the ray intersect any objects in LOS
            if (Physics.Raycast(owner.position, direction, out hit, 100f, layerMask))
            {
                Debug.Log("Did Hit " + hit.transform.name);
                navtarget.target = null;
            }
            else 
            { 
                navtarget.target = target;             
            }            

        }
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VizCone : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform owner;     //owner of the visibility cone
    public Transform target;    //specific Player target I am looking for

    public Navigation navigation;  //owner's navigation component to set target 
                                   //for the NavAgent Destination

    public bool enemyIsVisible = false;

    void Start()
    {
        navigation = owner.GetComponent<Navigation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {        
        //are there any "players" or NPCs in my viz cone?
        if (    other.transform.gameObject.layer == LayerMask.NameToLayer("Players") 
             || other.transform.gameObject.layer == LayerMask.NameToLayer("NPCs"))
        {
            Debug.Log("NPC/Player cones " + other.name);

            // Bit shift the index of the layer (7) to get a bit mask (the cool way)
            int layerMask = 1 << 7;  //which is the viz obstacles layer

            //we can also do this (not as cool, what if we change the name?)
            //layerMask = LayerMask.NameToLayer("VizObstacles");
            
            RaycastHit hit;

            //direction is "destination" minus "source"
            Vector3 direction =  other.transform.position - owner.position;

            direction.Normalize();

            // Does the ray intersect any objects in LOS
            if (Physics.Raycast(owner.position, direction, out hit, 100f, layerMask))
            {
                Debug.Log("Did Hit Obstruction " + hit.transform.name);

                //optional to be tweaked: can the player hide once found?
                //prolly put a distance check here before trashing the target.
                //navtarget.target = null;
            }
            else 
            {
                enemyIsVisible = true;
                target = other.transform;
            }            

        }
        
    }


}

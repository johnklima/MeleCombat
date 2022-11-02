using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSurface : MonoBehaviour
{

    public float desiredHeight = 1.0f;
    float curHeight;

    float prevY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Bit shift the index of the layer (3) to get a bit mask (the cool way)
        int layerMask = 1 << 3;  //which is the ground layer in my game

        //we can also do this (not as cool, what if we change the name?)
        //layerMask = LayerMask.NameToLayer("Ground");

        RaycastHit hit;        

        // Does the ray intersect any objects in LOS
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100f, layerMask))
        {
            Debug.Log("Did Hit Ground " + hit.transform.name);

            curHeight = hit.distance;
        }

        Vector3 pos = transform.position;
        Vector3 desired = pos;
        desired.y = desiredHeight;

        float offset = desiredHeight - pos.y;

        float veloY =  pos.y - prevY;

        prevY = pos.y;

        transform.position = Vector3.Lerp(pos, desired, Time.deltaTime);

    }
}

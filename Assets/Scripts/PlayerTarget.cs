using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the target to the point in the world where the player clicked
        if(Input.GetMouseButtonDown(0))
        {
            // Bit shift the index of the layer (3) to get a bit mask
            int layerMask = 1 << 3;  //which is the ground layer

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(ray, out hit, 100f, layerMask))
            {
                Debug.Log("Did Hit " + hit.transform.name);
                target.position = hit.point;
            }


        }
    }
}



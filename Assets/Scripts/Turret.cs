using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;       // the enemy
    public Rigidbody rigid;        // his rigid
    public Transform modelBullet;  // the bullet to instance
    private Transform nextBullet;  // the instanced bullet

    public float force =  100.0f;  // muzzle force

    private bool fire = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = CalculateAim();

        if (Input.GetKeyDown(KeyCode.Space))
        {           

            nextBullet = Instantiate(modelBullet);
            nextBullet.parent = transform;
            nextBullet.position = modelBullet.position;
            nextBullet.gameObject.SetActive(true);
            fire = true;


        }


    }
    private void FixedUpdate()
    {

        //physics must be in fixed update, so i need a fire flag to catch the keypress
        if (fire)
        {
            nextBullet.GetComponent<Rigidbody>().AddForceAtPosition
                (transform.forward * force, modelBullet.position, ForceMode.Impulse);

            fire = false;
        }
        
    }
    Vector3 CalculateAim()
    {
        //this uses "simple" prediction to lead the aim to where the enemy will likely be
        //by the time the bullet gets there.

        Vector3 p = target.position - transform.position; //direction from turret to target
        Vector3 v = rigid.velocity;                       //movement vector of target
        float   s = force;                                //speed of my bullet  

        float a = Vector3.Dot(v, v) - s * s;
        float b = Vector3.Dot(p, v);
        float c = Vector3.Dot(p, p);
        float d = b * b - a * c;

        if (d < 0.1f) return Vector3.zero;

        float sqrt = Mathf.Sqrt(d);
        float t1 = (-b - sqrt) / c;
        float t2 = (-b + sqrt) / c;

        float t = 0.0f;
        if (t1 < 0.0f && t2 < 0.0f) return Vector3.zero;
        else if (t1 < 0.0f) t = t2;
        else if (t2 < 0.0f) t = t1;
        else
        {

            t = Mathf.Max(new float[] { t1, t2 });
        }
        return t * p + v;
    }
}




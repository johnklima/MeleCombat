using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponState : State
{
    public float attackTimer = -1.0f;
    public float attackDuration = 2.0f;
    public bool doWeapon = false;

    public bool allowState = false;
    
    private MeshRenderer mesh;
    
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        if(attackTimer > 0 && Time.time - attackTimer < attackDuration)
        {
            //keep attacking            
            return;
        }
        else
        {
            //stop attack
            attackTimer = -1;
            isInState = false;
            mesh.enabled = false;
            doWeapon = false;
            return;
        }
    }

    
    public override bool processState(Transform owner)
    {

        //stop all others in the case that this weapon is in use
        if (doWeapon)
        {
            isInState = true;
            return isInState;
        }
           
        
        bool testchild = base.processState(owner);

        if (testchild)
        {
            Debug.Log("weapon process child true " + stateName);
            
            mesh.enabled = false;
            isInState = false;
            doWeapon = false;

            return testchild;
        }

        if (!allowState)
        {
            //set by the attack state to allow weapon to process
            //for this, we could also process attack prior to processing the base
            //therefor base (children) only get processed if attack is true

            mesh.enabled = false;
            isInState = false;
            doWeapon = false;

            return isInState;

        }

        if (doWeapon )
        {
            //if doing the weapon I want to keep doing it until the attackDuration completes
            Debug.Log("Doing weapon " + stateName);
            isInState = true;
            mesh.enabled = true;
            return isInState;
            
        }
        else
        {
            mesh.enabled = false;
            isInState = false;
            attackTimer = -1;            
        }

        

        //try this attack, this happens once per attackTime period
        float dice = Random.Range(0.0f, 1.0f);

        if(dice <= 0.33333333f)
        {
            isInState = true;
            mesh.enabled = true;
            attackTimer = Time.time;
            doWeapon = true;
        }
        
        
        return isInState;

    }
    public void allowStateAndChildren(bool allow)
    {

        //no point to change allow if it is already set to allow, either true or false
        if (allow == allowState)
            return;


        //this will traverse the weapons branches allowing/disallowing all
        allowState = allow;

        foreach (Transform child in transform)
        {
            //in this case we must be sure the child state is a weapon state
            //it might not be.
            WeaponState weapon = null;
            child.TryGetComponent<WeaponState>(out weapon);
            if (weapon)
                weapon.allowStateAndChildren(allow);
        }


    }
}

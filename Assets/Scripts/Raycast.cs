using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float range = 5;
    public TeleportToPoint tpScript;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if(Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if(hit.collider.tag == "Wall")
            {
                tpScript.ableToPort = false;
                //Debug.Log("Hitting a wall");
            }
        }
        if(!(Physics.Raycast(theRay, out RaycastHit hit2, range)) && tpScript.coolingDown == false)
        {
            tpScript.ableToPort = true;
            //Debug.Log("Hitting nothing");
        }
    }
}

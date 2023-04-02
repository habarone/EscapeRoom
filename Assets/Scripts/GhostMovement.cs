using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    //Speed is insanely fast be careful
    public float Speed = 0.00000005f;
    /*public*/ bool isFrozen = false;
    private Transform target;

    void Awake(){
        //make coordinates whereever ghost starts moving from
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);

    }

    void Start(){
        target = GameObject.Find("Player").transform;
    }

    public void Update(){
        //Speed = 5f;
       // isFrozen = false;
        var step =  Speed / 100 * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
      if(isFrozen == false){
        Speed = 5f;
      }
      //if (isFrozen == true){
       // Invoke(nameof(Go), 5f);
      //}
      }

      public void Go(){
        //if (isFrozen == true){
            Invoke(nameof(Update), 5f);
            Debug.Log("Ghost function works");
            //Speed += 5f;
        }
      
}



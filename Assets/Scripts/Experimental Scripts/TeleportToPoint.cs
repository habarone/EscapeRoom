using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToPoint : MonoBehaviour
{
    public GameObject teleportPoint;
    Vector3 telePos;
    // Start is called before the first frame update
    void Start()
    {
        telePos = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("q"))
        {
            telePos = teleportPoint.transform.position;
            this.transform.position = telePos;
            Debug.Log("Player has pressed q");
        }
    }
}

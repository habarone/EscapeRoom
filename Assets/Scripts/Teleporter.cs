using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public float tpmovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            this.transform.position = transform.position + new Vector3(tpmovement, 0f, 0f);
            Debug.Log("W is being pressed");
        }
    }
}

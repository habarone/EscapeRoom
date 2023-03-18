using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    public GameObject invisibilethings;

    // Start is called before the first frame update
    void Start()
    {
        invisibilethings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            invisibilethings.SetActive(true);
            Debug.Log("E is being pressed");
        }
        else { invisibilethings.SetActive(false); }
    }
}

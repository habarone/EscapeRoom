using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    public GameObject invisibilethings;
    public float invisibleCooldown = 10f;
    public bool ableToPress = true;

    // Start is called before the first frame update
    void Start()
    {
        invisibilethings.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            StartCoroutine(InvisibleReveal());
        }
    }

    IEnumerator InvisibleReveal()
    {
        float timer = 0f;
        while(timer < invisibleCooldown)
        {
            ableToPress = false;
            invisibilethings.SetActive(false);
            timer += Time.deltaTime;
            yield return null;
        }
        invisibilethings.SetActive(true);
    }
}

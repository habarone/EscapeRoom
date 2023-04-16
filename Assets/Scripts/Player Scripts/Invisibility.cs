using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    public GameObject invisibleThing1;
    public GameObject invisibleThing2;
    public GameObject invisibleThing3;
    public GameObject invisibleThing4;
    public GameObject invisibleThing5;

    public float invisibleCooldown = 10f;
    public bool ableToPress = true;

    AudioSource audioSource;
    public AudioClip invisibleClip;

    // Start is called before the first frame update
    void Start()
    {
        invisibleThing1.SetActive(true);
        invisibleThing2.SetActive(true);
        invisibleThing3.SetActive(true);
        invisibleThing4.SetActive(true);
        invisibleThing5.SetActive(true);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            audioSource.PlayOneShot(invisibleClip);
            StartCoroutine(InvisibleReveal());
        }
    }

    IEnumerator InvisibleReveal()
    {
        float timer = 0f;
        while(timer < invisibleCooldown)
        {
            ableToPress = false;
            invisibleThing1.SetActive(false);
            invisibleThing2.SetActive(false);
            invisibleThing3.SetActive(false);
            invisibleThing4.SetActive(false);
            invisibleThing5.SetActive(false);
            timer += Time.deltaTime;
            yield return null;
        }
        invisibleThing1.SetActive(true);
        invisibleThing2.SetActive(true);
        invisibleThing3.SetActive(true);
        invisibleThing4.SetActive(true);
        invisibleThing5.SetActive(true);
        //PLAY GLASSES OFF SOUND HERE
    }
}

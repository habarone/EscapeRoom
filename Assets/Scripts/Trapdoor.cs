using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    public float crackTime;
    private int timer;
    public GameObject trapdoor; 
    public AudioSource source;
    public AudioClip crack;
    public AudioClip destroyed;
    private int timesPlayed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && timesPlayed == 0)
        {
            timesPlayed++;
            source.PlayOneShot(crack);
            StartCoroutine(BreakProcess());
        }
    }

    IEnumerator BreakProcess()
    {
        float timer = 0f;
        while(timer < crackTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        source.PlayOneShot(destroyed);
        Destroy(trapdoor.gameObject);
    }

    
}

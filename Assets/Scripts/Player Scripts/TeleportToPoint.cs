using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToPoint : MonoBehaviour
{
    public GameObject teleportPoint;
    Vector3 telePos;
    public float cooldown = 5f;
    public bool ableToPort = true;
    public bool coolingDown = false;

    AudioSource audioSource;
    public AudioClip teleportClip;
    // Start is called before the first frame update
    void Start()
    {
        telePos = new Vector3(0f, 0f, 0f);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("q") && ableToPort)
        {
            audioSource.PlayOneShot(teleportClip);
            telePos = teleportPoint.transform.position;
            this.transform.position = telePos;
            StartCoroutine(TeleportCooldown());
            Debug.Log("Player has pressed q");
        }
    }

    IEnumerator TeleportCooldown()
    {
        float timer = 0f;
        while(timer < cooldown)
        {
            ableToPort = false;
            coolingDown = true;
            timer += Time.deltaTime;
            yield return null;
        }
        coolingDown = false;
        ableToPort = true;
    }
}

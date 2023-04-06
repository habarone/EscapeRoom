using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPatrolling : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed;
    public float originalSpeed;
    public float freezeTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
            transform.LookAt(points[current].position);
        }
        else
        {
            current = (current + 1) % points.Length;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FreezeProjectile")
        {
            //PLAY GHOST FREEZE SOUND HERE
            StartCoroutine(FreezingProcess());
            Destroy(other.gameObject);
            Debug.Log("Contact with ghost");
        }
    }

    IEnumerator FreezingProcess()
    {
        float timer = 0f;
        while(timer < freezeTime)
        {
            speed = 0;
            timer += Time.deltaTime;
            yield return null;
        }
        //PLAY GHOST DEFROST HERE
        speed = originalSpeed;
    }
}

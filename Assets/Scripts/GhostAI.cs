using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public GameObject bullet;
    public bool isFrozen;
    [SerializeField] float freezeTime = 3f;
 

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(isFrozen == false)
        {
            ChasePlayer();
        }
        else if(isFrozen == true)
        {
            StopMoving();
        }
    }

    private void ChasePlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }

    private void StopMoving()
    {
        agent.isStopped = true;
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
            isFrozen = true;
            timer += Time.deltaTime;
            yield return null;
        }
        isFrozen = false;
    }
}

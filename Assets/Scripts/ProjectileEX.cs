using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEX : MonoBehaviour
{
    private Vector3 firingPoint;

    [SerializeField]
    float projectileSpeed;

    [SerializeField]
    private float maxProjectileDistance;

    [SerializeField]
    private float freezeTime = 3f;

    void Start()
    {
        firingPoint = transform.position;
    }

    void Update()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        if(Vector3.Distance(firingPoint, transform.position) > maxProjectileDistance)
        {
            Destroy(this.gameObject);
        }   else
        {
            transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Freezable")
        {
            Debug.Log("Contact with freezable");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if(other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}

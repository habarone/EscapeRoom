using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FreezeRay : MonoBehaviour
{
    Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 direction, float force)
    {
        rigidbody.AddForce(direction * force);
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Projectile collided with " + other.gameObject);
        Destroy(gameObject);
    }
    
}

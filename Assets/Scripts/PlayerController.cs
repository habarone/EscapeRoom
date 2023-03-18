using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float turnSpeed = 360;
    private Vector3 input;
    float horizontal;
    float vertical;

    Vector2 lookDirection = new Vector2(1, 0);

    public GameObject projectilePrefab;
    void Update()
    {
        GatherInput();
        Look();
        if(Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
    }

    void FixedUpdate()
    {
        Move();
    }
    void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Look()
    {
        if(input != Vector3.zero)
        {

            var relative = (transform.position + input.ToIso()) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
    }

    void Move()
    {
        rb.MovePosition(transform.position + (transform.forward * input.magnitude) * speed * Time.deltaTime);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector3.up * 0.5f, Quaternion.identity);

        FreezeRay freezeBolt = projectileObject.GetComponent<FreezeRay>();
        freezeBolt.Launch(lookDirection, 300);

    }
}

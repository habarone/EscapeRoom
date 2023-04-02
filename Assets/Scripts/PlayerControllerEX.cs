using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerEX : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    private float speed;
    private bool isMoving;
    public Rigidbody rb;

    void Start()
    {
        speed = movementSpeed;
    }

    void Update()
    {
        HandleMovementInput();
        HandleRotationInput();
        HandleShootInput();
        if((!Input.GetKey("w")) && (!Input.GetKey("a")) && (!Input.GetKey("s")) && (!Input.GetKey("d")))
        {
            isMoving = false;
           // Debug.Log("Player is not moving");
        }
        else
        {
            isMoving = true;
           // Debug.Log("Player is moving");
        }
        if(!isMoving)
        {
            rb.velocity = Vector3.zero;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    void HandleMovementInput()
    {
        movementSpeed = speed;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(Quaternion.Euler(0, 45, 0) * (movement * movementSpeed * Time.deltaTime), Space.World);
    }

    void HandleRotationInput()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    void HandleShootInput()
    {
        if(Input.GetButton("Fire1"))
        {
            // Shoot
            PlayerGun.Instance.Shoot();
        }
    }

}

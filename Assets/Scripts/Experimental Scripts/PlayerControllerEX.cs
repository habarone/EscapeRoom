using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerEX : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField] private TrailRenderer tr;

    void Start()
    {

    }

    void Update()
    {
        HandleMovementInput();
        HandleRotationInput();
        HandleShootInput();
    }

    void HandleMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerEX : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    private float speed;
    private bool isMoving;
    public bool isPaused;
    public Rigidbody rb;
    public int lives = 3;
    public int ghostDamage = 1;
    private bool isHit = false;
    private bool isInvulnerable = false;
    public TextMeshProUGUI lifeCount;

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
        lifeCount.text = "Lives: " + lives.ToString();

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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GetDamaged();
        }
    }

    void GetDamaged()
    {
        lives -= ghostDamage;
        Debug.Log("Player took damage");
        if(isInvulnerable == false)
        {
            StartCoroutine("OnInvulnerable");
        }
    }

    IEnumerator OnInvulnerable()
    {
        isInvulnerable = true;
        ghostDamage = 0;
        yield return new WaitForSeconds(2f);
        ghostDamage = 1;
        isInvulnerable = false;
    }

}

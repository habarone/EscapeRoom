using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
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

    public Collectibles collectibleScript;

    public UnityEvent PlayerDeath;

    void Start()
    {
        speed = movementSpeed;
        collectibleScript = GetComponent<Collectibles>();
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
            //PLAY WALK ANIMATION HERE
           // Debug.Log("Player is moving");
        }
        if(!isMoving)
        {
            rb.velocity = Vector3.zero;
        }

        lifeCount.text = "Lives: " + lives.ToString();
        if(lives == 0)
        {
            PlayerDeath.Invoke();
            //INSERT PLAYER DEATH ANIMATION HERE
            //PLAY DEATH SOUND HERE
            StartCoroutine(ResetLevel());
        }

    }

    void HandleMovementInput()
    {
        movementSpeed = speed;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(Quaternion.Euler(0, 45, 0) * (movement * movementSpeed * Time.deltaTime), Space.World);
        //INSERT WALKING ANIMATION HERE
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
            //INSERT SHOOTING ANIMATION HERE
            //PLAY SHOOT SOUND HERE
            PlayerGun.Instance.Shoot();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            GetDamaged();
        }
        if(other.gameObject.tag == "WinTV")
        {
            if(collectibleScript.HMCount == 3)
            {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
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

    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

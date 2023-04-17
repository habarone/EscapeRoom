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
    public bool isMoving;
    public bool isPaused;
    public Rigidbody rb;
    public int lives = 3;
    public int ghostDamage = 1;
    private bool isHit = false;
    private bool isInvulnerable = false;
    public TextMeshProUGUI lifeCount;

    Animator animator;
    public Collectibles collectibleScript;

    public UnityEvent PlayerDeath;

    void Start()
    {
        speed = movementSpeed;
        collectibleScript = GetComponent<Collectibles>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovementInput();
        HandleRotationInput();
        HandleShootInput();
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(targetVelocity.x != 0 || targetVelocity.z != 0)
        {
            isMoving = true;
            animator.SetInteger("State", 1);
            //Debug.Log("State is set to: " +  animator.GetInteger("State"));
        }
        else
        {
            isMoving = false;
            animator.SetInteger("State", 0);
            //Debug.Log("State is set to: " +  animator.GetInteger("State"));
        }
    //    if((!Input.GetKey("w")) && (!Input.GetKey("a")) && (!Input.GetKey("s")) && (!Input.GetKey("d")))
    //    {
    //        isMoving = false;
    //        animator.SetInteger("State", 0);
    //        Debug.Log("State is set to: " +  animator.GetInteger("State"));
    //    }
    //    else
    //    {
    //        isMoving = true;
    //        animator.SetInteger("State", 1); 
    //        Debug.Log("State is set to: " +  animator.GetInteger("State"));
    //    }
        if(!isMoving)
        {
            rb.velocity = Vector3.zero;
        }

        lifeCount.text = "Lives: " + lives.ToString();
        if(lives == 0)
        {
            animator.SetInteger("State", 2);
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

        if(other.gameObject.tag == "Freezable")
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

    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

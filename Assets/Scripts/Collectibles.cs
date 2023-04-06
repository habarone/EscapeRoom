using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Collectibles : MonoBehaviour
{
    //ignore this, just for testing:
    
    public int HMCount = 0;
    public TextMeshProUGUI HMText;
    //for audio add:
    //public AudioSource audioSource; (audiosource should be added to player)
    //public AudioClip HMcountClip;

    // Start is called before the first frame update
    void Start()
    {
        //use if text is not showing a number on start up:
        //HMText.text = "HMCount(changethis): 0";
    }

    // Update is called once per frame
    void Update()
    {
         HMText.text = "HMCount(changethis): " + HMCount.ToString();

        //ignore this, just for testing:
        /* if(Input.GetKey("w")){
                transform.Translate((Vector2.up * speed )/ 100);
            }
        if(Input.GetKey("a")){
                transform.Translate((Vector2.left * speed )/ 100);
            }
        if(Input.GetKey("s")){
                transform.Translate((Vector2.down * speed )/ 100);
            }
        if(Input.GetKey("d")){
                transform.Translate((Vector2.right * speed )/ 100);
            } */
    }
    

    void OnTriggerEnter(Collider other){
        if(other.tag == "HMCollectible"){
            HMCount += 1;
            Destroy(other.gameObject);
            Debug.Log("pog");
            //for audio add: audioSource.PlayOneShot(HMcountClip);
        }

        if(other.tag == "WinTV")
        {
            if(HMCount == 3)
            {
                SceneManager.LoadScene("OfficeLevel");
            }
        }
    }
}

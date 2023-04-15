using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Collectibles : MonoBehaviour
{
    //ignore this, just for testing:
    
    public int HMCount = 0;
    public int LRCount = 0;
    public int CSCount = 0;
    public TextMeshProUGUI CollectibleText;
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
        if(SceneManager.GetSceneByName("HauntedMansion").isLoaded)
            {
                CollectibleText.text = "TV parts remaining: " + HMCount.ToString();
            }
            
            if(SceneManager.GetSceneByName("LivingRoom").isLoaded)
            {   
                CollectibleText.text = "Items remaining: " + LRCount.ToString();
            }

            if(SceneManager.GetSceneByName("CookingShow").isLoaded)
            {
                CollectibleText.text = "Ingredients remaining: " + CSCount.ToString();
            }
    }
    

    void OnTriggerEnter(Collider other){
        if(other.tag == "HMCollectible"){
            HMCount += 1;
            Destroy(other.gameObject);
            Debug.Log("pog");
            //for audio add: audioSource.PlayOneShot(HMcountClip);
        }

        if(other.tag == "LRCollectible")
        {
            LRCount += 1;
            Destroy(other.gameObject);
            Debug.Log("pog");
        }

        if(other.tag == "CSCollectible")
        {
            CSCount += 1;
            Destroy(other.gameObject);
            Debug.Log("pog");
        }

        if(other.tag == "HauntedMansionTV")
        {
            SceneManager.LoadScene("HauntedMansion");
            Debug.Log("Loading Haunted Mansion...");
        }

        if(other.tag == "LivingRoomTV")
        {
            //IF NAME OF SCENE IS DIFFERENT, CHANGE HERE
            SceneManager.LoadScene("LivingRoom");
            Debug.Log("Loading Living Room...");
        }

        if(other.tag == "CookingShowTV")
        {
            //IF NAME OF SCENE IS DIFFERENT, CHANGE HERE
            SceneManager.LoadScene("CookingShow");
            Debug.Log("Loading Cooking Show...");
        }
        if(other.tag == "HubTV")
        {
            //IF NAME OF SCENE IS DIFFERENT, CHANGE HERE
            if(SceneManager.GetSceneByName("HauntedMansion").isLoaded)
            {
                if(GameObject.FindGameObjectsWithTag("HMCollectible") == null)
                {
                    SceneManager.LoadScene("Office");
                    Debug.Log("Returning to Office...");
                }
            }
            
            if(SceneManager.GetSceneByName("LivingRoom").isLoaded)
            {
                if(GameObject.FindGameObjectsWithTag("LRCollectible") == null)
                {
                    SceneManager.LoadScene("Office");
                    Debug.Log("Returning to Office...");
                }
            }

            if(SceneManager.GetSceneByName("CookingShow").isLoaded)
            {
                if(GameObject.FindGameObjectsWithTag("CSCollectible") == null)
                {
                    SceneManager.LoadScene("Office");
                    Debug.Log("Returning to Office...");
                }
            }
        }

    }
}

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
    public static bool HMDone = false;
    public static bool LRDone = false;
    public static bool CSDone = false;

    public static int HMScore = 0;
    public static int LRScore = 0;
    public static int CSScore = 0;
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
                CollectibleText.text = "TV parts gathered: " + (HMCount / 2).ToString();
            }
            
            if(SceneManager.GetSceneByName("LavaLevel").isLoaded)
            {   
                CollectibleText.text = "Items gathered: " + (LRCount / 2).ToString();
            }

            if(SceneManager.GetSceneByName("Kitchen").isLoaded)
            {
                CollectibleText.text = "Ingredients gathered: " + (CSCount / 2).ToString();
            }
        if(GameObject.FindGameObjectsWithTag("CSCollectible") == null)
        {
            Debug.Log("No more collectibles");
        }
        
    }
    

    void OnTriggerEnter(Collider other){
        if(other.tag == "HMCollectible"){
            HMCount += 1;
            HMScore = HMCount / 2;
            Destroy(other.gameObject);
            Debug.Log("pog");
            //for audio add: audioSource.PlayOneShot(HMcountClip);
        }

        if(other.tag == "LRCollectible")
        {
            LRCount += 1;
            LRScore = LRCount / 2;
            Destroy(other.gameObject);
            Debug.Log("pog");
        }

        if(other.tag == "CSCollectible")
        {
            CSCount += 1;
            CSScore = CSCount / 2;
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
            SceneManager.LoadScene("LavaLevel");
            Debug.Log("Loading Living Room...");
        }

        if(other.tag == "CookingShowTV")
        {
            //IF NAME OF SCENE IS DIFFERENT, CHANGE HERE
            SceneManager.LoadScene("Kitchen");
            Debug.Log("Loading Cooking Show...");
        }
        if(other.tag == "HubTV")
        {
            //IF NAME OF SCENE IS DIFFERENT, CHANGE HERE
            if(SceneManager.GetSceneByName("HauntedMansion").isLoaded)
            {
                Debug.Log("MANSION IS LOADED");
                if(GameObject.FindWithTag("HMCollectible") == null)
                {
                    SceneManager.LoadScene("OfficeLevel");
                    HMDone = true;
                    Debug.Log("Returning to Office...");
                }
            }
            
            if(SceneManager.GetSceneByName("LavaLevel").isLoaded)
            {
                SceneManager.LoadScene("OfficeLevel");
                LRDone = true;
                Debug.Log("Returning to Office...");
            }

            if(SceneManager.GetSceneByName("Kitchen").isLoaded)
            {
                if(GameObject.FindWithTag("CSCollectible") == null)
                {
                    SceneManager.LoadScene("OfficeLevel");
                    CSDone = true;
                    Debug.Log("Returning to Office...");
                }
            }
        }
        if(other.tag == "WinTV")
        {
            if(HMDone && LRDone && CSDone)
            {
                //If win scene is different, rename scene here
                SceneManager.LoadScene("WinScreen");
            }
        }

    }
}

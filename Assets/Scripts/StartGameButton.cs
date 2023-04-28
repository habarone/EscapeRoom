using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public int gameStartScene;

    public GameObject SceneStart;
    private void Start()
    {
        Time.timeScale = 0;
        SceneStart.SetActive(true);
    }
    public void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            Time.timeScale = 1;
            SceneStart.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Hub()
    {
        SceneManager.LoadScene("OfficeLevel");
    }
}

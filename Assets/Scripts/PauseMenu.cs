using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public static bool Cheats = false;

    public GameObject pauseMenuUI;
    public GameObject cheatsMenuUI;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        cheatsMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (Cheats)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    void Close ()
    {
        cheatsMenuUI.SetActive(false);
        Cheats = false;
    }

    void Open ()
    {
        cheatsMenuUI.SetActive(true);
        Cheats = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public int gameMainMenu;
    public void Menu()
    {
        SceneManager.LoadScene(gameMainMenu);
    }
}

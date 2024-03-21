using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameplayLevel");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EndGame()
    {
        Application.Quit();
    }
}

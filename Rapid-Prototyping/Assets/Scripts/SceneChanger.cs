using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : GameBehaviour<SceneChanger>
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Title");
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("We have Quit the Game");
        Application.Quit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : GameBehaviour<SceneChanger>
{
    public GameObject pauseMenu;
    bool isPaused = false;
    //private void Awake()
    //{
    //    Time.timeScale = 1;
    //}

    private void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }
    public void Portfolio()
    {
        SceneManager.LoadScene("Portfolio");
    }

    public void Morball()
    {
        SceneManager.LoadScene("Title");
    }

    public void TreeMenu()
    {
        SceneManager.LoadScene("TreeTitle");
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void StartTreeGame()
    {
        SceneManager.LoadScene("Level Screen");
    }

    public void TreeTutorial()
    {
        SceneManager.LoadScene("TreeTutorial");
    }

    public void SpinGame()
    {
        SceneManager.LoadScene("SpinTitle");
    }
    public void SpinLevel()
    {
        SceneManager.LoadScene("Prototype3");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("We have Quit the Game");
        Application.Quit();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
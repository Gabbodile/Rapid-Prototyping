using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : GameBehaviour
{
    public GameObject pausePanel;
    bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        _GM.gameState = GameState.Playing;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    public void Pause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        _GM.gameState = isPaused ? GameState.Pause : GameState.Playing;
    }
}

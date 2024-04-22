using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    PlayerControls controls;
    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Pause.performed += ctx => PauseGame();
    }
    void Start()
    {
        Resume();
    }

    public void Resume()
    {
        Debug.Log("in resume");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
    }

    public void Pause()
    {
        Debug.Log("in pause");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
    }

    public void PauseGame()
    {
        Debug.Log("in pause game");
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }
}
using System;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public static GameOverMenu Instance {get; private set; }

    private void Awake()
    {
        Instance = this;
        pauseMenuUI.SetActive(false);
    }

    public void ShowEndGameMenu()
    {
        AudioManager.Instance.MuteAll();
        AudioManager.Instance.Play("fail");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NewGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 1f;
        GameManager.Instance.LoadGame();
    }
}
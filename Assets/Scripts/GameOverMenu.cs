using System.Collections;
using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject newBest;
    [SerializeField] private GameObject notNewBest;

    [SerializeField] private TextMeshProUGUI[] bestScoreTexts;
    [SerializeField] private TextMeshProUGUI[] currentScoreTexts;

    public static GameOverMenu Instance {get; private set; }

    private void Awake()
    {
        Instance = this;
        gameOverPanel.SetActive(false);
    }

    public void ShowEndGameMenu(bool isBest, int current, int best)
    {
        AudioManager.Instance.MuteAll();
        AudioManager.Instance.Play("fail");
        gameOverPanel.SetActive(true);
        newBest.SetActive(isBest);
        notNewBest.SetActive(!isBest);

        string bestStr = best.ToString();
        foreach (TextMeshProUGUI t in bestScoreTexts)
        {
            t.text = bestStr;
        }
        
        string currentStr = current.ToString();
        foreach (TextMeshProUGUI t in currentScoreTexts)
        {
            t.text = currentStr;
        }

        
        Time.timeScale = 0f;
    }

    public void NewGame()
    {
        //gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        AudioManager.Instance.Play("click");
        GameManager.Instance.LoadBasic("Game");
    }

    public void Quit()
    {
        AudioManager.Instance.Play("click");
        GameManager.Instance.LoadExitScreen();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.Play("click");
        GameManager.Instance.LoadBasic("Menu");
    }
}
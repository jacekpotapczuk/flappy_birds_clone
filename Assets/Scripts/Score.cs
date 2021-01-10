using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    
    private int score = 0;
    
    public void AddPoint()
    {
        AudioManager.Instance.Play("coin");
        score += 1;
        UpdateScoreText();
    }

    public void OnRestart()
    {
        score = 0;
        UpdateScoreText();
    }

    public void OnPlayerDeath()
    {
        bool isBest = score > BestScoreFileManager.Instance.Score; 
        if (isBest)
        {
            BestScoreFileManager.Instance.SaveScore(score);
        }
        GameOverMenu.Instance.ShowEndGameMenu(isBest, score, BestScoreFileManager.Instance.Score);
    }
    
    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
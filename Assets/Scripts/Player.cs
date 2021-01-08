using System;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D), typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private RepeatScroll[] scrollingObjects;
    
    [SerializeField, Range(0f, 20f)]
    private float clickForce = 5f;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;
    
    private bool godMode = false;
    private int score = 0;

    private Rigidbody2D rigidbody;
    private Animator animator;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector3(0f, -20f, 0f);
        animator = GetComponent<Animator>();
        if(GameManager.Instance.BlueSkinSelected)
            animator.SetBool("blueSkinSelected", true);
        else
            animator.SetBool("blueSkinSelected", false);


        bestScoreText.text = BestScore.Instance.Score.ToString();
        
        
        Restart();
    }

    private void Update()
    {

        if (Input.anyKeyDown && EventSystem.current.currentSelectedGameObject == null)
        {
            rigidbody.velocity = new Vector2(0f, clickForce);
            animator.SetBool("flap", true);
        }
        else
        {
            animator.SetBool("flap", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (godMode)
            return;
        
        GameOverMenu.Instance.ShowEndGameMenu();
    }


    public void ToggleGodMode(bool b)
    {
        godMode = b;
    }

    public void AddScore()
    {
        AudioManager.Instance.Play("coin");
        score += 1;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
        
        if (score > BestScore.Instance.Score)
        {
            Debug.Log("Nowy najlepszyu score!");
            BestScore.Instance.SaveScore(score);
            bestScoreText.text = score.ToString();
        }
    }

    private void Restart()
    {        
        transform.localPosition = new Vector3(-1.65f, 1.25f, 0f);


        
        score = 0;
        AudioManager.Instance.Play("main");
        UpdateScoreText();

        for (int i = 0; i < scrollingObjects.Length; i++)
        {
            scrollingObjects[i].ResetPosition();
        }
        
    }
    
}
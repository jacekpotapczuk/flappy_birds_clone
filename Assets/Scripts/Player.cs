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

    
    [SerializeField] private Sprite blueBird;
    [SerializeField] private Sprite pinkBird;

    private bool godMode = false;
    private int score = 0;

    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private int clickCount = 0;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
        Physics2D.gravity = new Vector3(0f, 0f, 0f);


        Restart();
    }

    private void Start()
    {
        if (GameManager.Instance.BlueSkinSelected)
        {
            print("Bluee....");
            animator.SetBool("blueSkinSelected", true);
            spriteRenderer.sprite = blueBird;
        }
        else
        {
            print("Pinkkk....");
            animator.SetBool("blueSkinSelected", false);
            spriteRenderer.sprite = pinkBird;
        }
    }

    private void Update()
    {
        if (Input.anyKeyDown && EventSystem.current.currentSelectedGameObject == null)
        {
            clickCount += 1;
            rigidbody.velocity = new Vector2(0f, clickForce);
            animator.SetBool("flap", true);
        }
        else
        {
            animator.SetBool("flap", false);
        }

        if (clickCount == 1)
        {
            Physics2D.gravity = new Vector3(0f, -20f, 0f);
        }
        if (clickCount >= 1)
        {
            foreach (RepeatScroll rs in scrollingObjects)
            {
                rs.UpdatePosition();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (godMode)
            return;

        bool isBest = score > BestScoreFileManager.Instance.Score; 
        if (isBest)
        {
            BestScoreFileManager.Instance.SaveScore(score);
        }
        GameOverMenu.Instance.ShowEndGameMenu(isBest, score, BestScoreFileManager.Instance.Score);
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
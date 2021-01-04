using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private PipesControler pipesControler;
    
    [SerializeField, Range(0f, 20f)]
    private float clickForce = 5f;

    [SerializeField] private Text scoreText;
    private bool godMode = false;
    private int score = 0;

    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector3(0f, -20f, 0f);
    }

    private void Update()
    {

        if (Input.anyKeyDown && EventSystem.current.currentSelectedGameObject == null)
        {
            rigidbody.velocity = new Vector2(0f, clickForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (godMode)
            return;
                
        transform.localPosition = new Vector3(-2f, 1.5f, 0f);
        score = 0;
        UpdateScoreText();
        pipesControler.Restart();
    }


    public void ToggleGodMode(bool b)
    {
        godMode = b;
    }

    public void AddScore()
    {
        score += 1;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
    
}
using System;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D), typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private RepeatScroll[] scrollingObjects; // all objects that are moving on screen, we update them
    // from Player so they don't move unless we know player is ready. Also this is faster than using unity's Update
    // for every object.
    
    [SerializeField, Range(0f, 20f)]
    private float clickForce = 5f;

    [SerializeField] private Sprite blueBird;
    [SerializeField] private Sprite pinkBird;

    [SerializeField] private Score score;
    
    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool playerClicked = false;
    private bool movementInitialized = false;
    private bool godMode = false;  // make player immortal, this option is hidden in game window at the bottom left corner

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
        Physics2D.gravity = new Vector3(0f, 0f, 0f);

        animator.enabled = false;
        Restart();
    }

    private void Start()
    {
        if (GameManager.Instance.BlueSkinSelected)
        {
            animator.SetBool("blueSkinSelected", true);
            spriteRenderer.sprite = blueBird;
        }
        else
        {
            animator.SetBool("blueSkinSelected", false);
            spriteRenderer.sprite = pinkBird;
        }
    }

    private void Update()
    {
        if (Input.anyKeyDown && EventSystem.current.currentSelectedGameObject == null)
        {
            playerClicked = true;
            rigidbody.velocity = new Vector2(0f, clickForce);
            animator.SetBool("flap", true);
        }
        else
        {
            animator.SetBool("flap", false);
        }

        if (!playerClicked)
            return;
                
        if (movementInitialized)
        {
            foreach (RepeatScroll rs in scrollingObjects)
            {
                rs.UpdatePosition();
            }
        }
        else
        {
            movementInitialized = true;
            Physics2D.gravity = new Vector3(0f, -20f, 0f);
            AudioManager.Instance.Play("main");
            animator.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (godMode)
            return;

        score.OnPlayerDeath();
    }


    public void ToggleGodMode(bool b)
    {
        godMode = b;
    }
    

    private void Restart()
    {        
        transform.localPosition = new Vector3(-1.65f, 1.25f, 0f);
        
        score.OnRestart();

        for (int i = 0; i < scrollingObjects.Length; i++)
        {
            scrollingObjects[i].ResetPosition();
        }
        
    }
    
}
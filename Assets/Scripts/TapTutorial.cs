using System;
using UnityEngine;

public class TapTutorial : MonoBehaviour
{

    private int counter = 0;
    private float timeLeft = 0.5f;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (Input.anyKeyDown)
        {
            counter += 1;
        }

        if (counter >= 1 && timeLeft <= 0f)
            gameObject.SetActive(false);
        
        if (Time.timeScale == 0)
            gameObject.SetActive(false);
    }
}
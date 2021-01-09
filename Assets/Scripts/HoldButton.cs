using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class HoldButton : MonoBehaviour
{
    [SerializeField, Range(0.1f, 5f)] private float howLongClick = 0.5f;
    [SerializeField] private Image progressBar;
    [SerializeField] private GameObject info;
    [SerializeField, Range(0.1f, 5f)] private float howLongInfo = 1f;
    
    private float timeLeft = -1f;
    private bool isActive = false;

    private void Start()
    {
        progressBar.fillAmount = 0f;
        info.SetActive(false);
    }

    public void PointerDown()
    {
        isActive = true;
        timeLeft = howLongClick;
        progressBar.fillAmount = 0f;
    }
    
    public void PointerUp()
    {
        isActive = false;
        progressBar.fillAmount = 0f;
    }

    private void Update()
    {
        if (!isActive)
            return;

        timeLeft -= Time.deltaTime;
        progressBar.fillAmount = (howLongClick - timeLeft) / howLongClick;
        if (timeLeft <= 0)
        {
            info.SetActive(true);
            StartCoroutine(DisableInfo());
            isActive = false;
            BestScoreFileManager.Instance.DeleteSave();
        }
    }

    private IEnumerator DisableInfo()
    {
        yield return new WaitForSeconds(howLongInfo);
        info.SetActive(false);
    }
}
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// custom button that requires user to hold it for howLongClick seconds before performing an action.
[RequireComponent(typeof(EventTrigger))]
public class HoldButton : MonoBehaviour
{
    [SerializeField, Range(0.1f, 5f)] private float howLongClick = 0.5f;  // how long user needs to hold the button
    [SerializeField, Range(0.1f, 5f)] private float howLongInfo = 1f;  // how long will the info be shown for
    [SerializeField] private Image progressBar;
    [SerializeField] private GameObject info;  // gameObject that is shown (for howLongInfo) after the click goes through
   
    [SerializeField] private UnityEvent onAction;
    private float timeLeft = -1f;
    private bool isActive = false;
    
    
    private void Start()
    {
        progressBar.fillAmount = 0f;
        info.SetActive(false);
        
        // add our listeners to event trigger 
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { PointerDown((PointerEventData)data); });
        trigger.triggers.Add(entry);
        
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerUp;
        entry.callback.AddListener((data) => { PointerUp((PointerEventData)data); });
        trigger.triggers.Add(entry);
        
        
    }

    public void PointerDown(PointerEventData data)
    {
        isActive = true;
        timeLeft = howLongClick;
        progressBar.fillAmount = 0f;
    }
    
    public void PointerUp(PointerEventData data)
    {
        isActive = false;
        progressBar.fillAmount = 0f;
    }

    private void Update()
    {
        if (!isActive)
            return;

        // update time left, update progress bar graphic based on that
        timeLeft -= Time.deltaTime;
        progressBar.fillAmount = (howLongClick - timeLeft) / howLongClick;
        if (timeLeft <= 0)
        {
            info.SetActive(true);
            StartCoroutine(DisableInfo());
            isActive = false;
            onAction.Invoke();
        }
    }

    private IEnumerator DisableInfo()
    {
        yield return new WaitForSeconds(howLongInfo);
        info.SetActive(false);
    }
}
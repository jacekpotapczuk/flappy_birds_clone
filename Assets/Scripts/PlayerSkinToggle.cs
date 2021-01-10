using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkinToggle: MonoBehaviour
{

    [SerializeField] private Toggle toggleBlue;
    [SerializeField] private Toggle togglePink;

    [SerializeField] private Animator animatorBlue;
    [SerializeField] private Animator animatorPink;

    
    private bool isInit = true;
    
    private void Start()
    {
        toggleBlue.isOn = true;
        togglePink.isOn = false;
        
    }
    

    public void ToggleBlueSkin(bool isOn)
    {
        GameManager.Instance.BlueSkinSelected = isOn;
        
        // when loading a scene this toggle isOn as default and that means that unity calls this function, even when user
        // didn't do anything. That's why we have to use this workaround to avoid unnecesary click sound.
        if (isInit)
        {
            isInit = false;
            return;
        }
        AudioManager.Instance.Play("click");

        if (isOn == true)
        {
            animatorBlue.SetBool("clicked", true);
            StartCoroutine(ClickOff(animatorBlue));
        }
    }

    public void TogglePinkSkin(bool isOn)
    {
        GameManager.Instance.BlueSkinSelected = !isOn;
        AudioManager.Instance.Play("click");
        
        if (isOn == true)
        {
            animatorPink.SetBool("clicked", true);
            StartCoroutine(ClickOff(animatorPink));
        }
    }
    
    
    private IEnumerator ClickOff(Animator animator)
    {
        yield return new WaitForEndOfFrame();
        animator.SetBool("clicked", false);
    }
}
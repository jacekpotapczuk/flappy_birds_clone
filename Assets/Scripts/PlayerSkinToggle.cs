using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkinToggle: MonoBehaviour
{

    [SerializeField] private Toggle toggleBlue;
    [SerializeField] private Toggle togglePink;

    private void Start()
    {
        toggleBlue.isOn = true;
        togglePink.isOn = false;
    }

    public void ToggleBlueSkin(bool isOn)
    {
        Debug.Log("Toggle Blue");
        GameManager.Instance.BlueSkinSelected = true;
        togglePink.isOn = !isOn;
    }
    
    public void TogglePinkSkin(bool isOn)
    {
        Debug.Log("Toggle Pink");
        GameManager.Instance.BlueSkinSelected = false;
        toggleBlue.isOn = !isOn;
    }
}
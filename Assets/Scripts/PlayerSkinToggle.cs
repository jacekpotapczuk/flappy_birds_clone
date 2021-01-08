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
        GameManager.Instance.BlueSkinSelected = isOn;
    }
    
    public void TogglePinkSkin(bool isOn)
    {
        //GameManager.Instance.BlueSkinSelected = !isOn;
    }
}
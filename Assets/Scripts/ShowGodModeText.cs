using System;
using UnityEngine;
using UnityEngine.UI;

// simple script to label what godMode toggle does if somebady manages to find it by accident
public class ShowGodModeText : MonoBehaviour
{
    [SerializeField] private Text myText;
    [SerializeField] private Image background;

    private void Awake()
    {
        GetComponent<Toggle>().isOn = false;
    }

    public void ToggleText(bool isOn)
    {
        if (isOn)
        {
            myText.text = "godMode";
            background.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            myText.text = "";
            background.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
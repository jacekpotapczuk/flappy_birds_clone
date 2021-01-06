using UnityEngine;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour
{

    private Toggle toggle;

    void Awake()
    {
        toggle = GetComponent<Toggle>();
    }
    
    void Start()
    {
        toggle.isOn = AudioManager.Instance.IsOn;
    }
    
    public void ToggleAudio(bool isOn)
    {
        AudioManager.Instance.ToggleAudio(isOn);
    }
}
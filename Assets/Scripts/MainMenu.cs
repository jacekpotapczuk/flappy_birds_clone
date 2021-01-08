using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LoadGame ()
    {
        GameManager.Instance.LoadBasic("Game");
        AudioManager.Instance.Play("click");
    }

}

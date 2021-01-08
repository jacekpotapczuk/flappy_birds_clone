using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LoadGame ()
    {
        GameManager.Instance.LoadGame();
        AudioManager.Instance.Play("click");
    }

}

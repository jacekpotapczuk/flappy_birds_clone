using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool BlueSkinSelected { get; set; }
    
    private Scene? currentlyLoadedScene;

    private void Awake()
    {
        Instance = this;
        LoadMainMenu();

        SceneManager.sceneLoaded += this.OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode sceceMode)
    {
        currentlyLoadedScene = scene;
        SceneManager.SetActiveScene(scene);
    }

    public void LoadMainMenu()
    {
        UnloadCurrentScene();
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
    
    public void LoadExitScreen()
    {
        UnloadCurrentScene();
        SceneManager.LoadScene("Exit", LoadSceneMode.Additive);
        StartCoroutine(QuitCoroutine());
    }
    
    private IEnumerator QuitCoroutine()
    {
        Time.timeScale = 1f;  // make sure time is on
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
    
    public void LoadGame()
    {
        UnloadCurrentScene();
        SceneManager.LoadScene("game", LoadSceneMode.Additive);
    }
    
    
    private void UnloadCurrentScene()
    {
        if(currentlyLoadedScene != null)
        {
            SceneManager.UnloadSceneAsync((Scene)currentlyLoadedScene);
            currentlyLoadedScene = null;
        }
    }
}
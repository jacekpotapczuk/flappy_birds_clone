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
        LoadBasic("Menu");

        SceneManager.sceneLoaded += this.OnSceneLoaded;
    }

    public void LoadBasic(string name) // unloads current scene (besides main) and loads given one in Additive mode
    {
        Debug.Assert(Application.CanStreamedLevelBeLoaded(name), $"Can't load scene {name}");
        UnloadCurrentScene();
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }
    
    
    public void OnSceneLoaded(Scene scene, LoadSceneMode sceceMode)
    {
        currentlyLoadedScene = scene;
        SceneManager.SetActiveScene(scene);
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
    
    private void UnloadCurrentScene()
    {
        if(currentlyLoadedScene != null)
        {
            SceneManager.UnloadSceneAsync((Scene)currentlyLoadedScene);
            currentlyLoadedScene = null;
        }
    }
}
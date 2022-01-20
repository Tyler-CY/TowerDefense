using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public int LevelSelectIndex;

    public void Start()
    {
        LevelSelectIndex = SceneManager.sceneCountInBuildSettings - 1;
    }
    public void Play()
    {
        sceneFader.FadeTo(LevelSelectIndex);
    }
    
    public void Quit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}

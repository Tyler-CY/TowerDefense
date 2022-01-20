using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text wavesText;

    public SceneFader sceneFader;
    public int menuBuildIndex = 0;

    void OnEnable()
    {
         wavesText.text = PlayerStats.wavesSurvived.ToString();
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuBuildIndex);
    }
}

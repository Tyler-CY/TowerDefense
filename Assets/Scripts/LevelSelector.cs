using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader sceneFader;

    public Button[] levelButtons;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }

    void FixedUpdate()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
            else
            {
                levelButtons[i].interactable = true;
            }
        }
    }
    public void SelectLevel(int levelBuildIndex)
    {
        sceneFader.FadeTo(levelBuildIndex);
    }

    public void Menu()
    {
        sceneFader.FadeTo(0);
    }

    public void ResetProgress()
    {
        //PlayerPrefs.DeleteAll();
        
        PlayerPrefs.SetInt("levelReached", 1);
    }

    public void UnlockAllLevels()
    {
        PlayerPrefs.SetInt("levelReached", levelButtons.Length);
    }
}

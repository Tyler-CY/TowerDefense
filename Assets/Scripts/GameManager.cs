using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject CompleteLevelUI;

    public SceneFader sceneFader;

    void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
            return;
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
   


        
        Debug.Log("GAME OVER!!");
    }

    public void WinLevel()
    {
        GameIsOver = true;
        CompleteLevelUI.SetActive(true);

        //Debug.Log("Level WON!");

        ///* Youtube comment
        // * You have to check before  this line of code  "PlayerPrefs.SetInt("levelReached", levelToUnlock);"  
        // * if the levelReached is geater than the saved value. 
        //    So you can just modify your code like this:
        //    if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        //*/

        //PlayerPrefs.SetInt("levelReached", PlayerPrefs.GetInt("levelReached") + 1);
        //sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

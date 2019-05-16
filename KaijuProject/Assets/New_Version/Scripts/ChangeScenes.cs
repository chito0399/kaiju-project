using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void FirstLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SecondLevel()
    {
        SceneManager.LoadScene("Level2");
    }

    public void FinalLevel()
    {
        SceneManager.LoadScene("Level3");
    }

    
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{

    public void ControlMenu()
    {
        SceneManager.LoadScene("ControlMenu");
    }

    public void CreatorMenu()
    {
        SceneManager.LoadScene("CreatorsMenu");
    }

    public void FirstLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FirstLevel");
    }

    public void MenuScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void SecondLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SecondLevel");
    }

}

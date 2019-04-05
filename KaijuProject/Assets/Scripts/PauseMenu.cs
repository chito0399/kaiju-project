using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool GameIsPause = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Pause")) {
            GameIsPause = !GameIsPause;
        }
        if (GameIsPause) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if (!GameIsPause) {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Resume() {
        GameIsPause = false;
    }
    public void Restart() {
        
        Application.LoadLevel(Application.loadedLevel);
    }
    public void MainMenu(){
        Application.LoadLevel("Menu");
    }
    public void Quit() {
        Application.Quit();
    }

}

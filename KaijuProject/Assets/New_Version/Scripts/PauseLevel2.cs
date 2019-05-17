using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLevel2 : MonoBehaviour
{
    public GameObject panelText;
    public bool pauseBool = false;
    // Start is called before the first frame update
    void Start()
    {
        panelText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape")) {
            //pauseBool = !pauseBool;
            //if (pauseBool)
            //{
                panelText.SetActive(true);
                Time.timeScale = 0;
            //}

            //else if (!pauseBool)
            //{
            //    panelText.SetActive(false);
            //    Time.timeScale = 1;
            //}

        }
    }
    public void Resume(){
        panelText.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("entra");
    }
    public void MainMenu() {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
    }
}

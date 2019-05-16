using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerX;
    public PlayerController player;
    public GameObject goCanvas;
    // Start is called before the first frame update
    void Start()
    {
        player = playerX.GetComponent<PlayerController>();
        goCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("Die");
            //SceneManager.LoadScene("Level1");
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
            Time.timeScale = 1;
        }
        if (player.finish)
        {
            goCanvas.SetActive(true);
        }
    }
}

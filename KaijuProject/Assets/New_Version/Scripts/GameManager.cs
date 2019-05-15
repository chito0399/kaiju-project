using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerX;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = playerX.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}

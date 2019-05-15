using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int heartNum;
    public GameObject playerX;
    public PlayerController player;

    public Image[] hearts;
    public Sprite full;
    public Sprite empty;

    void Start()
    {
        player = playerX.GetComponent<PlayerController>();
    }

   
    void Update()
    {
        if (player.health> heartNum)
        {
            player.health = heartNum;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i<player.health)
            {
                hearts[i].sprite = full;
            }
            else
            {
                hearts[i].sprite = empty;
            }
            if (i < heartNum)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = true;
            }
        }
    }
}

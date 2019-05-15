using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posion : MonoBehaviour
{
    public GameObject playerX;
    public PlayerController player;

    public bool healthy; 

    void Start()
    {
        player = playerX.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && healthy)
        {
            Destroy(gameObject);
            player.health++;
        }

        if (collision.gameObject.tag == "Player" && !healthy)
        {
            Destroy(gameObject);
            player.health--;
        }
    }
}

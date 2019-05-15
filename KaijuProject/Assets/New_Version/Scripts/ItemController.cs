using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject playerX;
    public PlayerController player;
    public float speed = -0.05F;

    void Start()
    {
        player = playerX.GetComponent<PlayerController>();
    }

    void Update()
    {
        gameObject.transform.Translate(new Vector3(speed, 0, 0));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && gameObject.tag == "Fire")
        {
            player.firePower = true;
            player.icePower = false; 
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player" && gameObject.tag == "Ice")
        {
            player.icePower = true;
            player.firePower = false;
            Destroy(gameObject);
        }

    }
}



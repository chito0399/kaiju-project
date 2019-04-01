using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject playerX;
    public Player player; 
    public int health;

    public void Start()
    {
        player = playerX.GetComponent<Player>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && health > 0)
        {
            health--;

        }
        else if (collision.tag == "Bullet2" && health > 0) {
            health -= 2;
        }
        else if ((collision.tag == "Bullet" || collision.tag == "Bullet2") && health <= 0)
        {
            Destroy(gameObject);
        }
        else if (collision.tag == "Player")
        {
            player.GetDamage(1);
        }
    }
}

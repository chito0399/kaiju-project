using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_R : MonoBehaviour
{
    public GameObject enemyX;
    public Enemy enemy;
    void Start()
    {
        enemy = enemyX.GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.attack=true;
        }
    }
}

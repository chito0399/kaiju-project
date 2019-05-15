using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    public GameObject playerX;
    public PlayerController player;
    private Transform objective;

    public float speed;
    public float stopD;
    public float stopDR;

    private float tbs;
    public float startTbs;

    public bool deathEn = false;
    public GameObject fire;
    public Transform fireP;

    public bool attack = false;

    public bool isFire;

    void Start()
    {
        objective = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = playerX.GetComponent<PlayerController>();

        tbs = startTbs;
    }

    void Update()
    {
        if (health <= 0)
        {
            EnemyDie();
        }
        if (attack == true)
        {
            Attack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.health=-5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFire)
        {
            if (collision.gameObject.tag == "Ice")
            {
                health--;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Fire")
            {
                health--;
            }
        }


    }

    private void EnemyDie()
    {
        deathEn = true;
        Destroy(gameObject);
    }

    public void Attack()
    {
        if (Vector2.Distance(transform.position, objective.position) > stopD)
        {
            transform.position = Vector2.MoveTowards(transform.position, objective.position, speed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, objective.position) < stopD && Vector2.Distance(transform.position, objective.position) > stopDR)
        {
            transform.position = this.transform.position;
        }

        else if (Vector2.Distance(transform.position, objective.position) < stopDR)
        {
            transform.position = Vector2.MoveTowards(transform.position, objective.position, -speed * Time.deltaTime);
        }

        if (tbs <= 0)
        {
            Instantiate(fire, fireP.position, Quaternion.identity);
            tbs = startTbs;
        }
        else
        {
            tbs -= Time.deltaTime;
        }
    }

}

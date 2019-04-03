using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Player protagonist;
    private Vector2 target;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        protagonist = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);

        if (transform.position.x == player.position.x && transform.position.y== player.position.y) {
            DestroyProjectile();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor") || other.CompareTag("Wall")) {
            DestroyProjectile();
        }
        else if (other.CompareTag("Player")) {
            DestroyProjectile();
            protagonist.GetDamage(2);
        }
    }

    void DestroyProjectile() {
        Destroy(gameObject);
    }
}

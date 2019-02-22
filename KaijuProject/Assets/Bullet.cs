using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    public  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("fireball")) {
            Debug.Log("funciona");
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

}

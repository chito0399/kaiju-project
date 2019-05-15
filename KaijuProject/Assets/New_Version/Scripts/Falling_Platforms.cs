using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Platforms : MonoBehaviour
{
    float timer;
    bool fall;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (fall)
        {
            timer += Time.deltaTime;
            float tr = 2f;
            if (timer >= tr)
            {
                GetComponent<Collider2D>().isTrigger = false;
                timer = 0;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Drop", 0.5f);
            fall = true; 
        }
    }

    void Drop()
    {
        rb.isKinematic = false;
    }
}

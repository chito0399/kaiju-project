using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Ball_Control : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;



    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}

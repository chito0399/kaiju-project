using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Manager : MonoBehaviour
{
    public float fm = 2.5f;
    public float ljm = 2f;
    Rigidbody2D rb; 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fm - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y < 0 && !Input.GetButton("space"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (ljm - 1) * Time.deltaTime;
        }
    }
}

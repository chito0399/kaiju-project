using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Control : MonoBehaviour
{
    public bool isFire;
    public int hp = 4; 

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFire == true)
        {
            if (collision.CompareTag("Fire"))
            {
                hp--;

            }
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.CompareTag("Ice"))
            {
                hp--;

            }
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}

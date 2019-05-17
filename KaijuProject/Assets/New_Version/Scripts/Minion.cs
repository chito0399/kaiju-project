using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    public GameObject startP;
    public GameObject endP;

    public bool isFire;

    public int health = 1; 

    public float speed;

    bool rightSide;

    void Start()
    {
        if (!rightSide)
        {
            transform.position = startP.transform.position;
        }
        else
        {
            transform.position = endP.transform.position;
        }
    }

    void Update()
    {
        if (!rightSide)
        {
            transform.position = Vector3.MoveTowards(transform.position, endP.transform.position, speed * Time.deltaTime);
            if (transform.position == endP.transform.position)
            {
                rightSide = true;
                //GetComponent<SpriteRenderer>().flipX = true;
                transform.Rotate(0f, 180f, 0f);
            }

        }
        if (rightSide)
        {
            transform.position = Vector3.MoveTowards(transform.position, startP.transform.position, speed * Time.deltaTime);
            if (transform.position == startP.transform.position)
            {
                rightSide = false;
                //GetComponent<SpriteRenderer>().flipX = false;
                transform.Rotate(0f, 180f, 0f);
            }

        }

        if (health <= 0)
        {
            transform.localScale += new Vector3(0, 0.9f, 0);
            Destroy(gameObject);
        }
    }

    /*public void OnDrawGizmos()
    {
        Gizmos.DrawLine(startP.transform.position, endP.transform.position);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ice" && isFire)
        {
            health--;
        }

        if (collision.gameObject.tag == "Fire" && !isFire)
        {
            health--;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool rightSide; 
    public float speed; 

    public GameObject startP;
    public GameObject endP; 
     
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
            transform.position = Vector3.MoveTowards(transform.position,endP.transform.position,speed*Time.deltaTime);
            if (transform.position == endP.transform.position)
            {
                rightSide = true;
                GetComponent<SpriteRenderer>().flipX = true;
            }

        }
        if (rightSide)
        {
            transform.position = Vector3.MoveTowards(transform.position, startP.transform.position, speed * Time.deltaTime);
            if (transform.position == startP.transform.position)
            {
                rightSide = false;
                GetComponent<SpriteRenderer>().flipX = false;
            }

        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(startP.transform.position, endP.transform.position);
    }
}

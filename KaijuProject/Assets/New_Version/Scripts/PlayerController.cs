﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    bool isGrounded = false;
    bool isRight; 
    public bool isJumping = false;
    public bool isRunning = false;

    public bool icePower = false;
    public bool firePower = false;

    public int health = 5;
    public int lives = 3;

    public bool fr = true;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            //gameObject.GetComponent<SpriteRenderer>().flipX = true;
            isRunning = true;
            isRight = true;
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            isRight = false;
        }

        if (isJumping && (Input.GetKeyDown("up") || Input.GetKeyDown("w")) && isGrounded && isRunning)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 80;
            gameObject.GetComponent<Animator>().SetBool("jumping", true);
            isGrounded = false;
            isJumping = false;
        }
        else if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && isGrounded)
        {
            StartCoroutine (NotJumping());
            isGrounded = false;
            isJumping = true;
            gameObject.GetComponent<Animator>().SetBool("jumping", true);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 55;
        }

        if (!Input.GetKey("a") && !Input.GetKey("left") && !Input.GetKey("d") && !Input.GetKey("right") && !Input.GetKeyDown("space"))
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
            isRunning = false;
        }

        if (isRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BadGround")
        {
            health = -5;
        }

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            gameObject.GetComponent<Animator>().SetBool("jumping", false);
        }

        if (collision.gameObject.tag == "Minion")
        {
            health--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "En_Shoot")
        {
            health--;
        }
    }


    IEnumerator NotJumping()
    {
        yield return new WaitForSeconds(1.5f);
        isJumping = false;
    }

    private void LiveController()
    {
        if (health <= 0)
        {
            lives--;
            
        }
    }
}
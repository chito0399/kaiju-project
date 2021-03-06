﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool invinsible = false;

    public bool fr = true;

    public bool finish = false;
    
    public int papers = 0;
    public Text paperText;
    //public GameObject panelText;
    //public bool pauseBool = false;
    void Start()
    {
        //panelText.SetActive(false);
        finish = false;
        if (paperText != null)
        {
            paperText.text = "0 / 4";
        }
    }

    void Update()
    {

        //if (Input.GetKey("escape")) {
        //    //pauseBool = !pauseBool;
        //    //if (pauseBool)
        //    //{
        //        panelText.SetActive(true);
        //        Time.timeScale = 0;
        //    //}

        //    //else if (!pauseBool)
        //    //{
        //    //    panelText.SetActive(false);
        //    //    Time.timeScale = 1;
        //    //}

        //}
       


        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("damage", false);
            gameObject.GetComponent<Animator>().SetBool("moving", true);

            //gameObject.GetComponent<SpriteRenderer>().flipX = true;
            isRunning = true;
            isRight = true;
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("damage", false);
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            isRight = false;
        }

        if (isJumping && (Input.GetKeyDown("up") || Input.GetKeyDown("w")) && isGrounded && isRunning)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 80;
            gameObject.GetComponent<Animator>().SetBool("jumping", true);
            FindObjectOfType<AudioManager>().Play("Jump");
            isGrounded = false;
            isJumping = false;
        }
        else if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && isGrounded)
        {
            StartCoroutine (NotJumping());
            isGrounded = false;
            isJumping = true;
            gameObject.GetComponent<Animator>().SetBool("damage", false);
            gameObject.GetComponent<Animator>().SetBool("jumping", true);
            FindObjectOfType<AudioManager>().Play("Jump");
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


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BadGround")
        {
            health = -5;
            gameObject.GetComponent<Animator>().SetBool("damage", true);
           
        }

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            gameObject.GetComponent<Animator>().SetBool("jumping", false);
        }

        if (collision.gameObject.tag == "Minion" && !invinsible)
        {
            health--;
            gameObject.GetComponent<Animator>().SetBool("damage", true);
            StartCoroutine(RedBlink());
            invinsible = true;

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "En_Shoot" || collision.gameObject.tag == "Enemy" && !invinsible)
        {
            health--;
            gameObject.GetComponent<Animator>().SetLayerWeight(1, 1);
            StartCoroutine(RedBlink());

            invinsible = true;
            //Debug.Log(invinsible);

        }
        if (collision.gameObject.CompareTag("goal"))
        {
            finish = true;
        }
        if (collision.gameObject.CompareTag("paper"))
        {
            Destroy(collision.gameObject);
            papers++;
            paperText.text = papers + " / 4";
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("goal"))
        {
            finish = false;
        }
    }


    IEnumerator NotJumping()
    {
        yield return new WaitForSeconds(1.5f);
        isJumping = false;
    }

    IEnumerator RedBlink()
    {
        yield return new WaitForSeconds(0.1f);
        invinsible = false;
        gameObject.GetComponent<Animator>().SetLayerWeight(1, 0);
        //Debug.Log(invinsible);
    }

    private void LiveController()
    {
        if (health <= 0)
        {
            lives--; 
            
        }
    }
}

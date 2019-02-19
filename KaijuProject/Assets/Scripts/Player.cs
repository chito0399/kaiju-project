using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxSpeed = 20;
    public float speed = 25f;
    public float jumpPower = 250f;
    public bool grounded;
    private Rigidbody2D rb2d;
    private Animator anim;
    public int numJumps = 0;


    public int curHealth;
    public int maxHealth=6;


    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetAxis("Horizontal") < -0.1f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > -0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetButtonDown("Jump") && numJumps < 2) {
            rb2d.AddForce(Vector2.up * jumpPower);
            numJumps++;
        }


        if (curHealth>maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth<= 0) {
            Die();
        }


    }

    void FixedUpdate()
    {

        //Vector3 easeVelocity = rb2d.velocity;
        //easeVelocity.y = rb2d.velocity.y;
        //easeVelocity.z = 0.0f;
        //easeVelocity.x *= 0.85f;
        float h = Input.GetAxis("Horizontal");

        ////Fake friction easing the x
        //if (grounded) {
        //    rb2d.velocity = easeVelocity;
        //}


        //moving the player

        rb2d.AddForce((Vector2.right*speed)*h);

        //limitng speed of the player

        if(rb2d.velocity.x>maxSpeed) {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

    }
    void Die() {
        Application.LoadLevel(Application.loadedLevel);
    
    }

}

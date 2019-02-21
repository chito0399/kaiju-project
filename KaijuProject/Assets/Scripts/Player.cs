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
    public int counterRight = 0;
    public int counterLeft = 0;
    public bool checkStartPosition = false;

    

    //for Sliding
    public bool wallSliding=false;
    public Transform wallCheckPoint;
    public bool wallCheck;
    public LayerMask wallLayerMask;
    public bool facingRight = true;

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

        if (Input.GetAxis("Horizontal") < -0.0f) {
            Debug.Log("Hola");
            counterLeft++;
            counterRight = 0;
            checkStartPosition = true;
            if (counterLeft==1)
            {
                transform.Rotate(0f, 180f, 0f);
            }
            //transform.localScale = new Vector3(-1, 1, 1);
            //transform.Rotate(0f, 180f, 0f);

            facingRight = false;
        }
        if (Input.GetAxis("Horizontal") > -0.0f)
        {
            Debug.Log("adios");
            counterRight++;
            counterLeft = 0;
            if (counterRight==1 && checkStartPosition) { 
                transform.Rotate(0f, 180f, 0f);
            }
            //transform.localScale = new Vector3(1, 1, 1);
            //transform.Rotate(0f, 180f, 0f);

            facingRight = true;

        }
        if (Input.GetButtonDown("Jump") && numJumps < 2 && !wallSliding) {
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
        if (!grounded) {
            wallCheck = Physics2D.OverlapCircle(wallCheckPoint.position, 0.1f, wallLayerMask);

            if (facingRight && Input.GetAxis("Horizontal")>0.1f || !facingRight && Input.GetAxis("Horizontal") < 0.1f)
            {
                if (wallCheck) {
                    HandleWallSliding();
                }
            }

        }
        if (!wallCheck || grounded) {
            wallSliding = false;
        }


    }

    void HandleWallSliding() {
        rb2d.velocity = new Vector2(rb2d.velocity.x, -0.7f);
        wallSliding = true;
        if (Input.GetButtonDown("Jump"))
        {
            if (facingRight) {
                rb2d.AddForce(new Vector2(-1, 2)*jumpPower);
            }
            else {
                rb2d.AddForce(new Vector2(1, 2) * jumpPower);
            }
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
        if (grounded) {
            rb2d.AddForce((Vector2.right * speed) * h);

        }
        else {
            //for sliding
            rb2d.AddForce((Vector2.right * speed/2) * h);
        }

        //limitng speed of the player

        if (rb2d.velocity.x>maxSpeed) {
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

   public void GetDamage(int dmg) {
        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("Player_redFlash");

    }

    public IEnumerator KnockBack(float knockDur, float knockbackPwr, Vector3 knockbackDir) {
        float timer = 0;
        while (knockDur>timer) {
            timer += Time.deltaTime;
            rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y*knockbackPwr, transform.position.z ));
        }

        yield return 0;
        
    }
    public void Flip() {
        transform.Rotate(0f, 180f, 0f);

    }

}

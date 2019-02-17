using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {


        player.grounded = true;
        player.numJumps = 0;
        Debug.Log("rererere");
        //if (collision.CompareTag("fireball")) {
        //    player.grounded = false;
        //    Debug.Log("hfaiosjfpoa");

        //}
        //else {
        //    player.grounded = true;
        //    player.numJumps = 0;
        //    Debug.Log("rererere");
        //}

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        player.grounded = true;


    }
    void OnTriggerExit2D(Collider2D collision)
    {
        player.grounded = false;

    }
}

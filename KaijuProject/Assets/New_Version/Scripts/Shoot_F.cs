using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_F : MonoBehaviour
{
    public GameObject playerX;
    public PlayerController player;

    public Transform fireP;
    public GameObject ball;

    void Start()
    {
        player = playerX.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (player.firePower == true && Input.GetKeyDown("space"))
        {
            Fire();
            player.GetComponent<Animator>().SetBool("shooting_Fire", true);
        }
        else
        {
            player.GetComponent<Animator>().SetBool("shooting_Fire", false);
        }

    }

    void Fire()
    {
        Instantiate(ball, fireP.position, fireP.rotation);
    }
}

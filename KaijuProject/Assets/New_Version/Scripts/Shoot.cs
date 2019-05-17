using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
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
        if (player.icePower == true && Input.GetKeyDown("space"))
        {
            Fire();
            //FindObjectOfType<AudioManager>().Play("Shoot");
            player.GetComponent<Animator>().SetBool("shooting", true);
        }
        else
        {
            player.GetComponent<Animator>().SetBool("shooting", false);
        }
    }

    void Fire()
    {
        Instantiate(ball, fireP.position, fireP.rotation);
    }
}

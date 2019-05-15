using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSign : MonoBehaviour
{
    public GameObject playerX;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = playerX.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.firePower==true)
        {
            gameObject.GetComponent<Animator>().SetBool("Fire_Active", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Fire_Active", false);
        }
    }
}

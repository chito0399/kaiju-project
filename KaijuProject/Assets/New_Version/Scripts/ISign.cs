using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISign : MonoBehaviour
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
        if (player.icePower == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Ice_Active", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Ice_Active", false);
        }
    }
}

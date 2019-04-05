using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSpike : MonoBehaviour
{
    // Start is called before the first frame update
    private Player player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            player.GetDamage(1);

            StartCoroutine(player.KnockBack(0.02f, 0.02f, player.transform.position));
        }
    }
}

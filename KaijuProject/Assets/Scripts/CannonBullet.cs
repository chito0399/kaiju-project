using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    public Player player;
    public int damage; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
    {
        gameObject.transform.Translate(new Vector3(0, 1f, 0));
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("MAMAmarrano");
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetDamage(1);
            Debug.Log("el cannon le dio al player");
           
        }
        Destroy(gameObject);


    }


}

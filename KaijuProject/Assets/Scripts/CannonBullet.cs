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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetDamage(damage);
            Debug.Log("el cannon le dio al player");
        }
        else
        {
            Destroy(gameObject);
        }
        

    }


}

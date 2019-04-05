using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeItem : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public Player protagonist;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        protagonist = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void Update()
    {

        if (Input.GetButtonDown("Fire2")) {
            Debug.Log("alansa");
        }
    }
    // Update is called once per frame
    public void Use()
    {
        if (protagonist.curHealth < 5) {
            protagonist.curHealth++;
            Destroy(gameObject);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTwoItem : MonoBehaviour
{

    private Transform player;
    public Player protagonist;
    public Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        protagonist = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>();

    }

    // Update is called once per frame
    public void Use() {
        weapon.power2 = true;
        weapon.countShots2 = 10;
        Destroy(gameObject);
    }
}

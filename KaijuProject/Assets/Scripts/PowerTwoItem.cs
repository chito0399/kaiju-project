using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTwoItem : MonoBehaviour
{

    private Transform player;
    public Player protagonist;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        protagonist = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    public void Use() {
        Destroy(gameObject);
    }
}

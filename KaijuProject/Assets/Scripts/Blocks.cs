using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{

    private bool used;                  //To indicate if the block has already been touced;
    public Transform newPower;         //The prefab of the new power.
    public GameObject positionPower;   //the position where the power will come out.

    // Start is called before the first frame update
    void Start()
    {
        used = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (used)
            {
                Transform power = Instantiate(newPower, positionPower.transform.position, positionPower.transform.rotation);
                used = !used;
            }
        }
    }
}

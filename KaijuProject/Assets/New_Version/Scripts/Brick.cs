using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject power;
    public ItemController itemC;

    public GameObject cube;

    void Start()
    {
        itemC = power.GetComponent<ItemController>();
        power.SetActive(false);
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cube.GetComponent<Animator>().SetBool("Used", true);
            power.SetActive(true);
        }
    }
}

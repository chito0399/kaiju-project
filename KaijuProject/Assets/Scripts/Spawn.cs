﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void SpawnItem() {
        Vector2 playerPos = new Vector2(player.position.x-5, player.position.y-2);
        Instantiate(item, playerPos, Quaternion.identity);
    }

}

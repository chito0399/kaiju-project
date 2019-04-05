﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaijuu : MonoBehaviour
{
    public float live = 50;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform firePoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public bool startShooting = false;

    public GameObject projectile;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector2.Distance(transform.position, player.position)> stoppingDistance) {
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //}
        //else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position)>retreatDistance) {
        //    transform.position = this.transform.position;
        //}else if (Vector2.Distance(transform.position, player.position) < retreatDistance) {
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        //}

        if (timeBtwShots <= 0 && startShooting ) {
            Instantiate(projectile, firePoint.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots; 
        }
        else {
            timeBtwShots -= Time.deltaTime;
        }
    }
}

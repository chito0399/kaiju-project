using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bullet2Prefab;
    public bool power2 = false;
    public int countShots2 = 8;
    



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
            
        }
    }
    void Shoot()
    {
        if (power2 && countShots2>=0)
        {
            Instantiate(bullet2Prefab, firePoint.position, firePoint.rotation);
            FindObjectOfType<AudioManager>().Play("Shoot1");
            countShots2--;
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            FindObjectOfType<AudioManager>().Play("Shoot1");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float timeDestroy; // time it delays to destroy
    public float timeFire;    // time it delays to shoot

    private bool inside; 

    public Transform fireball;

    // Start is called before the first frame update
    void Start()
    {
        inside = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shoot()
    {
        if (inside)
        {
            Debug.Log("fireball");
            yield return new WaitForSeconds(timeFire);
            Transform ball = Instantiate(fireball, transform.position, transform.rotation);
            Destroy(ball.gameObject, timeDestroy);
            StartCoroutine(Shoot());
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inside = true;
            StartCoroutine(Shoot());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        inside = false;
        StopCoroutine(Shoot());
    }
}

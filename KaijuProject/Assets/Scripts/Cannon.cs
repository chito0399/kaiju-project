using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float timeDestroy; // time it delays to destroy
    public float timeFire;    // time it delays to shoot

    private bool inside;

    public Transform cannonBall;

    public GameObject position;

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
            //Debug.Log("fireball");
            yield return new WaitForSeconds(timeFire);
            Transform cannonb = Instantiate(cannonBall, position.transform.position, position.transform.rotation);
            Destroy(cannonb.gameObject, timeDestroy);
            StartCoroutine(Shoot());
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Canon");
            inside = true;
            StartCoroutine(Shoot());
        }
    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    inside = false;
    //    StopCoroutine(Shoot());
    //}
}

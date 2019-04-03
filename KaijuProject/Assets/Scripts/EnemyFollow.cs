using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;
    public bool inside=false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Debug.Log("rarsafas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position)>3 && inside) {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") ) {
            Debug.Log("MaMAmarrano");
            inside = true;
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compuertas : MonoBehaviour
{
    public GameObject izquierda;
    public GameObject derecha;

    private Vector3 start_izq;
    private Vector3 start_der;

    public EnemyManager enemy;

    private Rigidbody2D rb_izq;        //RigidBody de la plataforma
    private Rigidbody2D rb_der;        //RigidBody de la plataforma
    
    public float fall = 1f;       //Tiempo en responder a la caída
    int enemyHealth;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemy.gameObject.GetComponent<EnemyManager>().health;
        start_izq = izquierda.transform.position;
        start_der = derecha.transform.position;

        rb_izq = izquierda.GetComponent<Rigidbody2D>();
        rb_der = derecha.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (enemyHealth <= 0)
        {
            rb_izq.transform.position = start_izq;
            rb_der.transform.position = start_der;

            rb_der.gravityScale = 0f;
            rb_izq.gravityScale = 0f;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fall);
        }
    }
    
    void Fall()
    {
        rb_izq.gravityScale = 98.1f;
        rb_der.gravityScale = 98.1f;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * La plataforma debe de tener rigidbody2D y ser kinematic
 * Y un polygon Collider2D
 * 
 * Si al tocar la plataforma, el jugador sigue siendo hijo de ella, cambiar a "Ground"
 * 
 * */



public class FallingPlatform : MonoBehaviour
{

    private Rigidbody2D rb;        //RigidBody de la plataforma
    private PolygonCollider2D pc;  //Collider de la plataforma

    private Vector3 start;         //Posisción inicial del juego. 

    public float fall = 1f;       //Tiempo en responder a la caída
    public float respawn = 5f;    //Tiempo que tardará en regresar a la posición inicial


    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PolygonCollider2D>();        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fall);
            Invoke("Respawn", fall + respawn);
        }
    }

    void Fall()
    {        
        rb.isKinematic = false;
        pc.isTrigger = true;        
    }

    void Respawn()
    {
        transform.position = start;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        pc.isTrigger = false;
    }


}

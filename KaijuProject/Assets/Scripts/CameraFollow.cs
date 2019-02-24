using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;

    public Vector2 minCamPos;
    public Vector2 maxCampPos;

    public float smoothTimex;
    public float smoothTimey;

    private Vector2 velocity; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posx = Mathf.SmoothDamp(transform.position.x,
            player.transform.position.x, ref velocity.x, smoothTimex);

        float posy = Mathf.SmoothDamp(transform.position.y,
            player.transform.position.y, ref velocity.y, smoothTimey);
            transform.position = new Vector3(posx, posy, transform.position.z);

        //transform.position = new Vector3(
            //Mathf.Clamp(posx, minCamPos.x, maxCampPos.x),
            //Mathf.Clamp(posy, minCamPos.y, maxCampPos.y),
            //transform.position.z);
           
    }
}
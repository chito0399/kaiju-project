using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;

    public Vector2 minCamPos;
    public Vector2 maxCampPos;

    public float smoothTime;

    private Vector2 velocity; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posx = Mathf.SmoothDamp(transform.position.x,
            player.transform.position.x, ref velocity.x, smoothTime);
        float posy = Mathf.SmoothDamp(transform.position.y,
            player.transform.position.y, ref velocity.y, smoothTime);

        transform.position = new Vector3(
            Mathf.Clamp(posx, minCamPos.x, maxCampPos.x),
            Mathf.Clamp(posy, minCamPos.y, maxCampPos.y),
            transform.position.z);

    }
}

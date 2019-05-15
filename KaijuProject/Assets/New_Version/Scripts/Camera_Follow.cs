using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    private Transform playerT;

    public float offsetX;
    public float offsetY;

    void Start()
    {
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = playerT.position.x;
        temp.y = playerT.position.y;

        temp.x += offsetX;
        temp.y += offsetY;

        transform.position = temp;
    }
}

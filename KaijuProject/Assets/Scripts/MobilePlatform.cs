using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    // Lugar a donde vamos
    public Transform[] Targets;
    public int _targetIndex = 0;

    // Velocidad que tenemos
    public float Speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    void GetNextTarget()
    {
        _targetIndex++;
        _targetIndex = _targetIndex % Targets.Length;
    }

    void MoveToTarget()
    {
        float distance = Vector3.Distance(transform.position, Targets[_targetIndex].position);
        if (distance <= 0)
        {
            GetNextTarget();
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, Targets[_targetIndex].position, (Time.deltaTime * Speed) / distance);
        }

    }
}

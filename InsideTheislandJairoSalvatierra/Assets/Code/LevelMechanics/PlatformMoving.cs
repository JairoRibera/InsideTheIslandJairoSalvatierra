using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    public int currentPoint;
    public Transform _platformPosition;
    // Update is called once per frame
    void Update()
    {
        _platformPosition.position = Vector3.MoveTowards(_platformPosition.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(_platformPosition.position, points[currentPoint].position) < 0.01f)
        {   
            currentPoint++; 
            if (currentPoint >= points.Length)
                currentPoint = 0;
        }
    }
}

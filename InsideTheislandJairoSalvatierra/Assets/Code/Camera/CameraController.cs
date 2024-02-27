using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public float minHeight, maxHeight;
    private Vector2 _lastPos;
    // Start is called before the first frame update
    void Start()
    {
        _lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
        _lastPos = transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public float minHeight, maxHeight;
    public Transform farBackground, middle1, middle2, middle3, nubes;
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
        Vector2 _amountToMove = new Vector2(transform.position.x - _lastPos.x, transform.position.y - _lastPos.y);
        farBackground.position = farBackground.position + new Vector3(_amountToMove.x, _amountToMove.y, 0f);
        middle1.position += new Vector3(_amountToMove.x, _amountToMove.y, 0f) * .5f;
        middle2.position += new Vector3(_amountToMove.x, _amountToMove.y, 0f) * .75f;
        middle3.position += new Vector3(_amountToMove.x, _amountToMove.y, 0f) * .85f;
        nubes.position += new Vector3(_amountToMove.x, _amountToMove.y, 0f) * .5f;
        _lastPos = transform.position;
    }
}

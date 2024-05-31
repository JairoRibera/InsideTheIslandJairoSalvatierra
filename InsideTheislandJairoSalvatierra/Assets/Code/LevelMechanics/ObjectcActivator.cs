using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectcActivator : MonoBehaviour
{
    public bool isActive = false;
    public Transform[] points;
    public float speed;
    public int currentPoint;
    private Vector3 initialPos;
    Collider2D _trampCollider;


    public void Start()
    {
        initialPos = transform.position;
        foreach (Transform p in points)
        {
            p.parent = null;
        }
        GetComponent<EdgeCollider2D>();
    }
    public void ActivateObject()
    {
        transform.position = Vector3.MoveTowards(points[currentPoint].position, points[currentPoint].position, speed * Time.deltaTime);
        //StartCoroutine(DeactivateTrap());
    }
    public void DesactivateObject()
    {
        //StartCoroutine(DesactTrampCo());
      
    }
    //private IEnumerator DesactTrampCo()
    //{
    //    yield return new WaitForSeconds(6f);
    //}

    private IEnumerator DeactivateTrap()
    {
        yield return new WaitForSeconds(6f);
        transform.position = Vector3.MoveTowards(initialPos, initialPos, speed * Time.deltaTime);
        GetComponent<ObjectcActivator>().isActive = false;
        
    }
}


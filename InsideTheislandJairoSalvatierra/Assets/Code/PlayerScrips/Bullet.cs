using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 2f;
    public Rigidbody2D _rB;
    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("bullet"))
        {
            _rB.velocity = new Vector2(bulletSpeed, 0f);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

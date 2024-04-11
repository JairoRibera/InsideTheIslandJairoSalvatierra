using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public Rigidbody2D _rB;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        //if (CompareTag("bullet"))
        //{
        //    _rB.velocity = new Vector2(bulletSpeed, 0f);
        //}
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
   private void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }
    //private void OnTriggerEnter2D(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //        other.GetComponent<EnemyDeath>().damageEnemy(damage);
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            collision.GetComponent<EnemyDeath>().damageEnemy(damage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public Rigidbody2D _rB;
    public float damage;
    private float lifetime = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        //if (CompareTag("bullet"))
        //{
        //    _rB.velocity = new Vector2(bulletSpeed, 0f);
        //}
        Destroy(gameObject, lifetime);
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
        {
            collision.GetComponent<EnemyDeath>().damageEnemy(damage);
            Destroy(gameObject);
        }  
        if (collision.CompareTag("Enemy2"))
        {
            collision.GetComponent<EnemyDeath>().damageEnemy(damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossVida>().TomarDaño(damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("EnemyGeneratorPlant"))
        {
            collision.GetComponent<EnemyDeath>().damageEnemy(damage);
            Destroy(gameObject);
        }

    }

}

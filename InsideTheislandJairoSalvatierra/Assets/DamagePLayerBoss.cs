using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePLayerBoss : MonoBehaviour
{
 private float enemyPos;
    private void Start()
    {
        enemyPos = transform.parent.position.x;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealthController>().DealWithDamage(enemyPos);
        }
    }
}

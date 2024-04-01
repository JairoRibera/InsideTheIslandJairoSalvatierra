using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    //public GameObject deathEffect;
    public void EnemyDeathController()
    {
        
        transform.gameObject.SetActive(false);
        //Instantiate(deathEffect, transform.GetChild(0).position, transform.GetChild(0).rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            EnemyDeathController();
        }
    }
}

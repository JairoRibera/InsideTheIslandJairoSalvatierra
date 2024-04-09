using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField]private float vida;
    //public GameObject deathEffect;
    public void damageEnemy(float damage)
    {
        vida -= damage;
        if (vida <= 0)
            EnemyDeathController();
    }
    public void EnemyDeathController()
    {
        Destroy(gameObject);
        //transform.gameObject.SetActive(false);
        //Instantiate(deathEffect, transform.GetChild(0).position, transform.GetChild(0).rotation);
    }
    
}

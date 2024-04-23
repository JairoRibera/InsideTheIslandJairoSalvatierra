using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float vida;
    public bool isLife;
    //public GameObject deathEffect;
    public void damageEnemy(float damage)
    {
        vida -= damage;
        if (vida <= 0)
            EnemyDeathController();
    }
    public void EnemyDeathController()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
        //transform.gameObject.SetActive(false);
        //Instantiate(deathEffect, transform.GetChild(0).position, transform.GetChild(0).rotation);
    }
    public void estaVivo()
    {
        if (vida > 0)
            isLife = true;
    }
}

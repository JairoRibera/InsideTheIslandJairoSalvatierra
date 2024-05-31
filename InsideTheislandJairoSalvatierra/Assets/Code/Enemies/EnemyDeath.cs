using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject deathEffect;
    public float vida;
    public bool isLife;
    private LevelManager _lMReference;
    private void Start()
    {
        _lMReference = GameObject.Find("LevelManagers").GetComponent<LevelManager>();
    }
    //public GameObject deathEffect;
    public void damageEnemy(float damage)
    {
        vida -= damage;
        if (vida <= 0)
            EnemyDeathController();
    }
    public void EnemyDeathController()
    {
        transform.gameObject.SetActive(false);
        AudioManager.audioMReference.PlaySFX(5);
        Instantiate(deathEffect, transform.position, transform.rotation);
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

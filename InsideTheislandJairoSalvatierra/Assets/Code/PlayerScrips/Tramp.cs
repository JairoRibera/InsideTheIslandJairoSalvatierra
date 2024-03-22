using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramp : MonoBehaviour
{
    public Rigidbody2D rb;
    
    //Variable para nombre del enemigo
    string enemyName;
    public void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.transform.position = transform.position;
            collision.gameObject.GetComponent<EnemiesController>().canMove = false;
            collision.gameObject.GetComponent<EnemiesController>().rB.velocity = Vector2.zero;
            //Hacemos que la variable enemyName sea el nombre que esté en colision con la trampa
            enemyName = collision.gameObject.name;
            //Iniciamos la Corrutina
            StartCoroutine(EnemyMoveCo());
           
        }
        if (collision.CompareTag("Enemy2"))
        {
            collision.transform.position = transform.position;
            collision.gameObject.GetComponent<EnemyPersecution>().debePerseguir = false;
            collision.gameObject.GetComponent<EnemyPersecution>().enemySpeed = 0f;
            enemyName = collision.gameObject.name;

            StartCoroutine(EnemyPersecutionCo());
        }
        if (collision.CompareTag("EnemyRun"))
        {
            collision.transform.position = transform.position;
            collision.gameObject.GetComponent<EnemyRun>().debeHuir = false;
            collision.gameObject.GetComponent<EnemyRun>().enemySpeed = 0f;
            enemyName = collision.gameObject.name;

            StartCoroutine(EnemyRunCo());
        }

    }   
    private IEnumerator EnemyPersecutionCo()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        GameObject.Find(enemyName).GetComponent<EnemyPersecution>().debePerseguir = true;
        GameObject.Find(enemyName).GetComponent<EnemyPersecution>().enemySpeed = 5f;
    }
    private IEnumerator EnemyMoveCo()
    {
        yield return new WaitForSeconds(3f);
        //Destruimos el objeto
        Destroy(gameObject);
        //buscamos el objeto con el nombre de la variable y hacemos que pueda moverse
        GameObject.Find(enemyName).GetComponent<EnemiesController>().canMove = true;
    }
   private IEnumerator EnemyRunCo()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        GameObject.Find(enemyName).GetComponent<EnemyRun>().debeHuir = true;
        GameObject.Find(enemyName).GetComponent<EnemyRun>().enemySpeed = 4f;

    } 
}

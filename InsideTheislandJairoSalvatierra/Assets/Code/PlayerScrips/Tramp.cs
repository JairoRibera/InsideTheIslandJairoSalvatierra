using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramp : MonoBehaviour
{
    //public Rigidbody2D rb;
    public bool isLife;
    
    //Variable para nombre del enemigo
    string enemyName;
    void Start()
    {
        
    }
    public void Update()
    {
        StartCoroutine(EliminateTramp());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            Vector2 posEnemigo = new Vector2(transform.position.x, collision.transform.position.y);
            collision.transform.position = posEnemigo;
            collision.gameObject.GetComponent<EnemiesController>().canMove = false;
            collision.gameObject.GetComponent<EnemiesController>().rB.velocity = Vector2.zero;
            StartCoroutine(collision.gameObject.GetComponent<GeneradorObjetos>().GenerarItemPlumaCo());
            //Hacemos que la variable enemyName sea el nombre que esté en colision con la trampa
            enemyName = collision.gameObject.name;
            //Iniciamos la Corrutina
            StartCoroutine(EnemyMoveCo());
            

        }
        if (collision.CompareTag("Enemy2"))
        {
            Vector2 posEnemigo = new Vector2(transform.position.x, collision.transform.position.y);
            collision.transform.position = posEnemigo;
            collision.gameObject.GetComponent<EnemyPersecution>().debePerseguir = false;
            collision.gameObject.GetComponent<EnemyPersecution>().enemySpeed = 0f;
            enemyName = collision.gameObject.name;
            StartCoroutine(EnemyPersecutionCo());


        }
        if (collision.CompareTag("EnemyRun"))
        {
            Vector2 posEnemigo = new Vector2(transform.position.x, collision.transform.position.y);
            collision.transform.position = posEnemigo;
            collision.gameObject.GetComponent<EnemyRun>().debeHuir = false;
            collision.gameObject.GetComponent<EnemyRun>().enemySpeed = 0f;
            enemyName = collision.gameObject.name;
            StartCoroutine(EnemyRunCo());



        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") )
        {
           
            collision.GetComponent<EnemiesController>().canMove = true;
            collision.GetComponent<EnemiesController>().moveSpeed = 15f;
        }
        if (collision.CompareTag("Enemy2"))
        {
            collision.GetComponent<EnemyPersecution>().debePerseguir = true;
            collision.GetComponent<EnemyPersecution>().enemySpeed = 10f;
        }
        if (collision.CompareTag("EnemyRun"))
        {
            collision.GetComponent<EnemyRun>().debeHuir = true;
            collision.GetComponent<EnemyRun>().enemySpeed = 5f;
        }
    }
    private IEnumerator EnemyPersecutionCo()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
        //GameObject.Find(enemyName).GetComponent<EnemyPersecution>().debePerseguir = true;
        //GameObject.Find(enemyName).GetComponent<EnemyPersecution>().enemySpeed = 10f;
    }
    private IEnumerator EnemyMoveCo()
    {
        
        yield return new WaitForSeconds(3f);
        //Destruimos el objeto
        Destroy(gameObject);
        //buscamos el objeto con el nombre de la variable y hacemos que pueda moverse
        //GameObject.Find(enemyName).GetComponent<EnemiesController>().canMove = true;
        //GameObject.Find(enemyName).GetComponent<EnemiesController>().moveSpeed = 15f;
    }
   private IEnumerator EnemyRunCo()
    {
        
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        //GameObject.Find(enemyName).GetComponent<EnemyRun>().debeHuir = true;
        //GameObject.Find(enemyName).GetComponent<EnemyRun>().enemySpeed = 5f;

    } 
    private IEnumerator EliminateTramp()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

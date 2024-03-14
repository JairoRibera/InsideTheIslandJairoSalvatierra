using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramp : MonoBehaviour
{
    public Rigidbody2D rb;
    //Variable para nombre del enemigo
    string enemyName;
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
    }
    private IEnumerator EnemyMoveCo()
    {
        yield return new WaitForSeconds(3f);
        //Destruimos el objeto
        Destroy(gameObject);
        //buscamos el objeto con el nombre de la variable y hacemos que pueda moverse
        GameObject.Find(enemyName).GetComponent<EnemiesController>().canMove = true;
    }
   
}

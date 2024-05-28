using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Para que se destruya a los 5 segundos
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //Aqui va el codigo de hacer daño al jugador
        }
        Destroy(gameObject);
    }
}

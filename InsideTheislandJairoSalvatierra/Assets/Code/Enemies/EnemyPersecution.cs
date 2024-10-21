using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPersecution : MonoBehaviour
{
    public GameObject _player;
    public bool debePerseguir;
    public float enemySpeed = 5f;
    public Rigidbody2D rB;
    public float distance;
    private SpriteRenderer _sR;
    public void Start()
    {
        _sR = GetComponent<SpriteRenderer>();
        _player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        //La distancia que debe de recorrer es la del jugador - la del enemigo
        distance = (_player.transform.position - transform.position).magnitude;
        //Si la booleana se cumple, movemos con MoveToward, indicando su posicion, la del jugador, la velocidad
        if (debePerseguir == true)
        { 
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, enemySpeed * Time.deltaTime);
        }
        if (distance > 0)
        {
            transform.Rotate(new Vector3(0f, 0f, 0f));
            //transform.localScale = new Vector3(1, 1, 1);

        }
        if (distance < 0)
        {
            transform.Rotate(new Vector3(0f, -180f, 0f));
            //transform.localScale = new Vector3(-1, 1, 1);

        }
        if (distance < 10)
        {
            debePerseguir = true;
        }
        else
        {
            debePerseguir = false;
        }
        //Esto es para rotar el sprite del enemigo
        if (transform.position.x < _player.transform.position.x)
            _sR.flipX = true;
        else if (transform.position.x > _player.transform.position.x)
            _sR.flipX = false;
    }  
}

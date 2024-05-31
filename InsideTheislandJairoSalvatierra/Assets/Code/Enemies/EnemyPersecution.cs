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
        
        distance = (_player.transform.position - transform.position).magnitude;

        if (debePerseguir == true)
        { 
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, enemySpeed * Time.deltaTime);
        }
        if (distance > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        if (distance < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
        if (distance < 10)
        {
            debePerseguir = true;
        }
        else
        {
            debePerseguir = false;
        }
        if (transform.position.x < _player.transform.position.x)
            _sR.flipX = true;
        else if (transform.position.x > _player.transform.position.x)
            _sR.flipX = false;
    }  
}

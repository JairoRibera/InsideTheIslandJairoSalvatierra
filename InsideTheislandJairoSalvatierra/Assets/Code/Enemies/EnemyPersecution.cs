using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPersecution : MonoBehaviour
{
    public GameObject player;
    public bool debePerseguir;
    public float enemySpeed;
    public Rigidbody2D rB;
    public float distance;
    // Update is called once per frame
    void Update()
    {
        distance = (player.transform.position - transform.position).magnitude;

        if (debePerseguir == true)
        { 
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
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
    }  
}

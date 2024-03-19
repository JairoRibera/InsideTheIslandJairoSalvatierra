using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPersecution : MonoBehaviour
{
    Vector2 PlayerPos;
    public GameObject player;
    public bool debePerseguir;
    public float enemySpeed;
    public Rigidbody2D rB;
    //public float distance;
    //public float distanceA;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //distance = player.transform.position.x - transform.position.x;
        //distanceA = Mathf.Abs(distance);
        //if(debePerseguir = true)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, PlayerPos, enemySpeed * Time.deltaTime);
        //}
        //if(distance > 0)
        //{
        //    transform.localScale = new Vector3(1, 1, 1);
        //}
        //if (distance < 0)
        //{
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}
        //if(distanceA < 5)
        //{
        //    debePerseguir = true;
        //}
        //else
        //{
        //    debePerseguir = false;
        //}
        if (debePerseguir)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPos, enemySpeed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, PlayerPos) > 12f)
        {
            debePerseguir = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            PlayerPos = player.transform.position;
            debePerseguir = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        debePerseguir = false;
    }
    
}

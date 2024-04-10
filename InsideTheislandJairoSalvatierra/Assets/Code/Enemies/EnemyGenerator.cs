using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public Transform point;
    public bool generateEnemy;
    public GameObject player;
    public float distance;
    public GameObject enemyRun;
    public bool debeHuir;
    public int numberOfEnemies = 1;
    public float cooldownTime;
    float lastEnemy;
    int contador;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        distance = (player.transform.position - transform.position).magnitude;
        if (distance <= 10)
        {
            generateEnemy = true;
            GeneratorEnemy();
        }
        else
            generateEnemy = false;
    }
    public void GeneratorEnemy()
    {
        if (generateEnemy == true && contador < 5)
        {
            if (Time.time - lastEnemy < cooldownTime)
                return;
            lastEnemy = Time.time;
            Instantiate(enemyRun, point.transform.position, point.transform.rotation);
            contador++;
        }
    }
}

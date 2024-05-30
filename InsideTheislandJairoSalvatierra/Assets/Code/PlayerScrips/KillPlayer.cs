using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    
    private LevelManager _lMReference;
    // Start is called before the first frame update
    void Start()
    {
        _lMReference = GameObject.Find("LevelManagers").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _lMReference.RespawnPlayer();
            _lMReference.RespawnEnemy();
        }
    }
}

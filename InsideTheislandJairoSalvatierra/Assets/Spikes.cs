using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private LevelManager _lMreference;
    private PlayerMovement _pMReference;
    // Start is called before the first frame update
    void Start()
    {
        _lMreference = GameObject.Find("LevelManagers").GetComponent<LevelManager>();
        _pMReference = GameObject.Find("Player").GetComponent<PlayerMovement>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _lMreference.RespawnPlayer();
            _lMreference.RespawnEnemy();
            _pMReference.normalStats();


        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite cpOn, cpOff;
    private SpriteRenderer _sR;
    private CheckPointController _cReference;
    // Start is called before the first frame update
    void Start()
    {
        _sR = GetComponent<SpriteRenderer>();
        _cReference = transform.parent.GetComponent<CheckPointController>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _cReference.DesactivateCheckpoints();
            _sR.sprite = cpOn;
            _cReference.SetSpawnPoint(transform.position);
        }
    }
    public void ResetCheckpoint()
    {
        _sR.sprite = cpOff;
    }
}

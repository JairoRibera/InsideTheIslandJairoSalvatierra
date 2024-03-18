using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckPointController _cReference;
    // Start is called before the first frame update
    void Start()
    {
        _cReference = transform.parent.GetComponent<CheckPointController>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _cReference.DesactivateCheckpoints();
            _cReference.SetSpawnPoint(transform.position);
        }
    }
    public void ResetCheckpoint()
    {

    }
}

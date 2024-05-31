using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{

    private Checkpoint[] _checkpoints;
    public Vector3 spawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {

        _checkpoints = GetComponentsInChildren<Checkpoint>();
        spawnPoint = GameObject.Find("Player").transform.position;
    }
    public void DesactivateCheckpoints()
    {
        foreach (Checkpoint c in _checkpoints)
        {
            c.ResetCheckpoint();
        }
    }
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }

}

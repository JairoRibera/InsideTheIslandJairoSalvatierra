using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComeBackScene : MonoBehaviour
{
    private LevelManager _lMReference;
    private PlayerMovement _pM;
    // Start is called before the first frame update
    void Start()
    {
        _lMReference = GameObject.Find("LevelManagers").GetComponent<LevelManager>();
        _pM = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            comeBack();
        }
    }

    public void comeBack()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        LevelManager.escenaAnterior = escenaActual;
        SceneManager.LoadScene(escenaActual - 1);
        
    }
}

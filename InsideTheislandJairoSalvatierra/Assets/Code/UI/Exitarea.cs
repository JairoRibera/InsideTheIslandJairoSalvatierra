using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exitarea : MonoBehaviour
{
    public string sceneToLoad;
    public string areaTransitionName;
    PlayerMovement _pM;
    // Start is called before the first frame update
    void Start()
    {
        _pM = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetString("areaTransitionNameV", areaTransitionName);
            SceneManager.LoadScene(sceneToLoad);
            
        }
    }
}

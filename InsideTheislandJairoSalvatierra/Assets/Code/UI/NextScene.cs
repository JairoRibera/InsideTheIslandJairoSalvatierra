using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    PlayerHealthController _pH;

    // Start is called before the first frame update
    void Start()
    {
        _pH = GameObject.Find("Player").GetComponent<PlayerHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            NextLevel();
        }
    }
    public void NextLevel()
    {
        int actualScene = SceneManager.GetActiveScene().buildIndex;
        LevelManager.escenaAnterior = actualScene;
        PlayerPrefs.SetInt("Lifes", _pH.currentHealth);
        SceneManager.LoadScene(actualScene + 1);
    }
}

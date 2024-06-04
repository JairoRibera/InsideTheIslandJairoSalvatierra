using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ComeBackCartel : MonoBehaviour
{
    public GameObject infoPanel;
    private bool isInRange;
    private void Update()
    {
        if (isInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            GoToMainMenu();
        }

    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infoPanel.SetActive(true);
            isInRange = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infoPanel.SetActive(false);
            isInRange = false;
        }


    }
}

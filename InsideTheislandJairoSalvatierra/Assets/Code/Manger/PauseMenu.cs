using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Referencia al gameObject menu de pausa
    public GameObject pauseMenu;
    public GameObject optionMenu;

    public bool isPaused;
    // Start is called before the first frame update
    //void Start()
    //{
    //    pauseMenu.SetActive(false);
    //    optionMenu.SetActive(false);
    //}

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Return)|| Input.GetButtonDown(""))
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PauseGame();
            //if (isPaused)
            //{
            //    ResumeGame();
            //    ResumeGameFromOM();
            //}
            //else
            //{
            //    PauseGame();
            //}
        }
        //if (isPaused)
        //    Input.GetButtonDown("ButtonA");
    }

    public void PauseGame()
    {
        if(isPaused)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            //Reanudamos el tiempo de juego
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        ////Cursor.visible = true;
        //pauseMenu.SetActive(true);
        //Time.timeScale = 0f;
        //isPaused = true;
    }

    public void ResumeGame()
    {
        //Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void ShowOMMenu()
    {
        //Cursor.visible = true;
        optionMenu.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGameFromOM()
    {
        //Cursor.visible = false;
        pauseMenu.SetActive(false);
        optionMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    //public void GoLS()
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("LevelSelector");
    //}

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void Resume()
    {
        PauseGame();
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

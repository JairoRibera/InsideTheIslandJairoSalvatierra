using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int escenaAnterior;
    public int escenaPlay;
    public bool isComeBack;
    public Transform comebackPos;
    public Vector2 initialPos;
    public float waitToRespawn;
    private PlayerMovement _pM;
    private CheckPointController _cReference;
    private PlayerHealthController _pHReference;
    private UIController _uIReference;
    public int coinCollected;
    // Start is called before the first frame update
    void Start()
    {
        
        _pHReference = GameObject.Find("Player").GetComponent<PlayerHealthController>();
        _pM = GameObject.Find("Player").GetComponent<PlayerMovement>();
        _cReference = GameObject.Find("CheckPointController").GetComponent<CheckPointController>();
        _uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        //if (escenaAnterior != escenaPlay)
        //{
        //    _pM.transform.position = comebackPos.transform.position;
        //}
    }
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());
    }
    public IEnumerator RespawnPlayerCo()
    {
        _pM.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        _pM.gameObject.SetActive(true);
        _pM.transform.position = _cReference.spawnPoint;
        _pHReference.currentHealth = _pHReference.maxHealth;
        _uIReference.UpdateHealthDisplay();

    }
    public void ExitLevel()
    {
        StartCoroutine(ExitLevelCo());
    }
    public IEnumerator ExitLevelCo()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");
    }

}

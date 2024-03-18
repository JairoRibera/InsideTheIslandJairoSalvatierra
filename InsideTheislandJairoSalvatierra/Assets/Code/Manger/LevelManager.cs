using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float waitToRespawn;
    public int coin;
    private PlayerMovement _pM;
    private CheckPointController _cReference;

    // Start is called before the first frame update
    void Start()
    {
        _pM = GameObject.Find("Player").GetComponent<PlayerMovement>();
        _cReference = GameObject.Find("CheckPointController").GetComponent<CheckPointController>();
    }
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());
    }
    private IEnumerator RespawnPlayerCo()
    {
        _pM.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        _pM.gameObject.SetActive(true);
        _pM.transform.position = _cReference.spawnPoint;

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

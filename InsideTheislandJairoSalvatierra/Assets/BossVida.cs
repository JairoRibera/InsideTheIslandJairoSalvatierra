using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVida : MonoBehaviour
{
    [SerializeField] public float vida;
    [SerializeField] public float maximoVida;
    [SerializeField] private BarraDeVida barraDeVida;
    public GameObject deathBoss, panelWin, panelComeBack;
    // Start is called before the first frame update
    void Start()
    {
        vida = maximoVida;
        barraDeVida.InicializarBarraDeVida(vida);
    }
    public void TomarDaño(float daño)
    {
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if(vida <= 0)
        {
            EnemyDeathController();
        }
    }
    public void EnemyDeathController()
    {
        panelComeBack.gameObject.SetActive(true);
        panelWin.gameObject.SetActive(true);
        barraDeVida.gameObject.SetActive(false);
        Instantiate(deathBoss, transform.position, transform.rotation);
        AudioManager.audioMReference.PlaySFX(5);
        transform.gameObject.SetActive(false);
        //Destroy(gameObject);
        //transform.gameObject.SetActive(false);
        //Instantiate(deathEffect, transform.GetChild(0).position, transform.GetChild(0).rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

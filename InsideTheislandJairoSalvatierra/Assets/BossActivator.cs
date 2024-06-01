using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public GameObject Boss;
    public GameObject BarraDeVida;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Boss.SetActive(true);
            BarraDeVida.SetActive(true);
            gameObject.SetActive(false);
            AudioManager.audioMReference.PlayBossMusic();
        }
    }
}

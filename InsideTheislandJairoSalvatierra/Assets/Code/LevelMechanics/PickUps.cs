using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public bool isCoin, isHeal, isPowerJump, isPowerShoot;
    private bool _isCollected;
    public LevelManager _lMReference;
    private UIController _uIReference;
    private PlayerHealthController _pHReference;
    public Bullet _bReference;
    private PlayerMovement _pMReference;
    // Start is called before the first frame update
    void Start()
    {
        _lMReference = GameObject.Find("LevelManagers").GetComponent<LevelManager>();
        _uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        _pHReference = GameObject.Find("Player").GetComponent<PlayerHealthController>();
        //_bReference = GameObject.Find("Bullet").GetComponent<Bullet>();
        _pMReference = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !_isCollected)
        {
            if (isCoin)
            {
                _lMReference.coinCollected++;
                _uIReference.UpdateCoinCount();
                _isCollected = true;
                AudioManager.audioMReference.PlaySFX(1);
                Destroy(gameObject);
            }
            if ((isHeal))
            {
                if(_pHReference.currentHealth != _pHReference.maxHealth)
                {
                    _pHReference.HealPlayer();
                    _isCollected = true;
                    AudioManager.audioMReference.PlaySFX(2);
                    Destroy(gameObject);
                }
                
            }
            if (isPowerJump)
            {
                _pMReference.doblueJump();
                //_pMReference.jumpForce = 15f;
                _isCollected = true;
                AudioManager.audioMReference.PlaySFX(2);
                Destroy(gameObject);
            }
            if (isPowerShoot)
            {
                _bReference.damage = 40f;
                _bReference.bulletSpeed = 15f;
                _isCollected = true;
                AudioManager.audioMReference.PlaySFX(2);
                Destroy(gameObject);
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public bool isCoin, isHeal, isPowerJump, isPowerShoot;
    private bool _isCollected;
    private LevelManager _lMReference;
    private UIController _uIReference;
    private PlayerHealthController _pHReference;
    public Bullet _bReference;
    private PlayerMovement _pMReference;
    // Start is called before the first frame update
    void Start()
    {
        //_lMReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        //_uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        _pHReference = GameObject.Find("Player").GetComponent<PlayerHealthController>();
        //_bReference = GameObject.Find("Bullet").GetComponent<Bullet>();
        _pMReference = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !_isCollected)
        {
            if (isCoin)
            {
                
            }
            if ((isHeal))
            {
                if(_pHReference.currentHealth != _pHReference.maxHealth)
                {
                    _pHReference.HealPlayer();
                    _isCollected = true;
                    Destroy(gameObject);
                }
                
            }
            if (isPowerJump)
            {
                _pMReference.jumpForce = 15f;
                _isCollected = true;
                Destroy(gameObject);
            }
            if (isPowerShoot)
            {
                _bReference.damage = 40f;
                _bReference.bulletSpeed = 15f;
                _isCollected = true;
                Destroy(gameObject);
            }

        }
    }
}

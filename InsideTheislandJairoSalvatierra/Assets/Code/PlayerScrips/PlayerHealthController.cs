using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealthController : MonoBehaviour
{
    [HideInInspector] public int currentHealth;
    public int maxHealth;
    public float invencibleLength;
    private float _invencibleCounter;
    private UIController _uIReference;
    private PlayerMovement _pMReference;
    private LevelManager _lReference;
    public GameObject deathEffect;
    private SpriteRenderer _sR;
    // Start is called before the first frame update
    void Start()
    {  
        _lReference = GameObject.Find("LevelManagers").GetComponent<LevelManager>();
        _uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        _pMReference = GetComponent<PlayerMovement>();
        _sR = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(_invencibleCounter > 0)
        {
            _invencibleCounter -= Time.deltaTime;
            if (_invencibleCounter <= 0)
                _sR.color = new Color(_sR.color.r, _sR.color.g, _sR.color.b, 1f);
            
        }
    }
    public void DealWithDamage(float EnemyPosX)
    {
        if(_invencibleCounter <= 0)
        {
            currentHealth--;
            if(currentHealth <= 0)
            {
                currentHealth = 0;
                //StartCoroutine(_pMReference.normalSJ())
                GameObject instance = Instantiate(deathEffect, transform.position, transform.rotation);
                instance.GetComponent<PlayerDeathEffect>().wasSeeLeft = GetComponent<PlayerMovement>().seeLeft;
                _lReference.RespawnPlayer();
                _lReference.RespawnEnemy();
                _pMReference.normalStats();
            }
            else
            {
                _invencibleCounter = invencibleLength;
                _sR.color = new Color(_sR.color.r, _sR.color.g, _sR.color.b, .5f);
                _pMReference.ApplyKnockBack(EnemyPosX);
            }
            _uIReference.UpdateHealthDisplay();
        }
    }
    public void HealPlayer()
    {
        currentHealth++;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        _uIReference.UpdateHealthDisplay();
    }
}

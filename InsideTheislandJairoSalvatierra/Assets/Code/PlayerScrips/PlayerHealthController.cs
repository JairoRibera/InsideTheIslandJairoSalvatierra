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
    // Start is called before the first frame update
    void Start()
    {
        _uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        _pMReference = GetComponent<PlayerMovement>();
       //_lReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(_invencibleCounter > 0)
        {
            _invencibleCounter -= Time.deltaTime;
            
        }
    }
    public void DealWithDamage()
    {
        if(_invencibleCounter <= 0)
        {
            currentHealth--;
            if(currentHealth <= 0)
            {
                currentHealth = 0;
                //_lReference.RespawnPlayer();
            }
            else
            {
                _invencibleCounter = invencibleLength;
                _pMReference.ApplyKnockBack(transform.position.x);
            }
            //_uIReference.UpdateHealthDisplay();
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

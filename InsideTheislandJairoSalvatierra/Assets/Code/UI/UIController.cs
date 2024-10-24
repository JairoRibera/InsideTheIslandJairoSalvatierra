using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public Image heart1, heart2, heart3;
    public Sprite heartFull, heartEmpty;
    private PlayerHealthController _pHReference;
    private LevelManager _lMReference;
    public TextMeshProUGUI coinText;
    // Start is called before the first frame update
    void Start()
    {
        _pHReference = GameObject.Find("Player").GetComponent<PlayerHealthController>();
       _lMReference = GameObject.Find("LevelManagers").GetComponent<LevelManager>();
        UpdateCoinCount();
    }
    public void UpdateHealthDisplay()
    {
        switch (_pHReference.currentHealth)
        {
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;
            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;

        }
    }
    public void UpdateCoinCount()
    {
        coinText.text = _lMReference.coinCollected.ToString();
    }

    
}


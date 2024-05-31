using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathEffect : MonoBehaviour
{
    private SpriteRenderer _sR;
    public bool wasSeeLeft;
    // Start is called before the first frame update
    void Start()
    {
        _sR = GetComponent<SpriteRenderer>();
        if (wasSeeLeft == true)
            _sR.flipX = true;
        else
            _sR.flipX = false;
    }
}

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public float moveSpeed;
    public Transform LeftPoint, RightPoint;
    public bool movingRight;
    public float moveTime, waitTime;
    private float _moveCount, _waitCount;
    public Rigidbody2D rB;
    public bool canMove = true;
    public Transform GeneradorObjeto;
    private SpriteRenderer _sR;
    // Start is called before the first frame update
    void Start()
    {
        _sR = GetComponentInChildren<SpriteRenderer>();
        LeftPoint.parent = null;
        RightPoint.parent = null;
        _moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            if (_moveCount > 0)
            {
                _moveCount -= Time.deltaTime;
                if (movingRight)
                {
                    rB.velocity = new Vector2(moveSpeed, rB.velocity.y);
                    _sR.flipX = true;

                    if (transform.position.x > RightPoint.position.x)
                        movingRight = false;
                }
                else
                {
                    rB.velocity = new Vector2(-moveSpeed, rB.velocity.y);
                    _sR.flipX = false;
                    
                    if (transform.position.x < LeftPoint.position.x)
                        movingRight = true;
                }
                if (_moveCount <= 0)
                {
                    _waitCount = Random.Range(waitTime * 0.25f, waitTime * 1.25f);
                }
            }
            else if (_waitCount > 0)
            {
                _waitCount -= Time.deltaTime;
                rB.velocity = new Vector2(0f, rB.velocity.y);
                if (_waitCount <= 0)
                {
                    _moveCount = moveTime;
                }
            }
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    public float moveJump;
    public int currentPoint;
    public float distanceToAttackPlayer, chaseSpeed;
    private Vector3 attackTarget;
    public float waitAfterAttack;
    private float _attackCounter;
    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        foreach(Transform p in points)
        {
            p.parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_attackCounter > 0)
            _attackCounter -= Time.deltaTime;
        else
        {
            if(Vector3.Distance(transform.position, _player.transform.position) > distanceToAttackPlayer)
            {
                attackTarget = Vector3.zero;
                transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed + moveJump * Time.deltaTime);
                if(Vector3.Distance(transform.position, points[currentPoint].position) < 0.01f)
                {
                    currentPoint++;
                    if (currentPoint >= points.Length)
                        currentPoint = 0;
                }
                //if (transform.position.x < points[currentPoint].position.x)
                //    _sR.flipX = true;
                //else if (transform.position.x > points[currentPoint].position.x)
                //    _sR.flipX = false;

            }
            else
            {
                if (attackTarget == Vector3.zero)
                    attackTarget = _player.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);
                if(Vector3.Distance(transform.position, attackTarget) <= 0.1f)
                {
                    _attackCounter = waitAfterAttack;
                    attackTarget = Vector3.zero;
                }
            }
        }
    }
}

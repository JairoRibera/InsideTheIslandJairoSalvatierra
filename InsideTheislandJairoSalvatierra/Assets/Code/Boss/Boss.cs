using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int phase = 0;
    private Animator anim;
    private Rigidbody2D rb;
    public Transform player;
    [Header("Fase 1")]
    public float distance = 2f; //Distamcia para mantener respecto al jugador
    public float attackDistance = 2f;
    public float moveSpeed = 3f;
    public float attackCooldown = .5f;
    public bool canAttack = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (phase)
        {
            case 0:
                MeleeAtack();
                //va hacia el jugador y ataca melee
                break;
            case 1:
                break;
            case 2:
                break;
        }

        
    }
    private void FixedUpdate()
    {
        ChasePlayer();
    }
    void ChasePlayer()
    {
        //Calcular la direccion hacia el jugador para aplicar la velocity
        Vector2 _dirToPlayer = player.position - transform.position;
        _dirToPlayer.y = 0;
        //comprueba la distancia respecto al jugador para no perseguirle 
        if(_dirToPlayer.magnitude <= distance)
        {
            return;
        }
        rb.velocity = _dirToPlayer.normalized * moveSpeed;
        if(_dirToPlayer.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_dirToPlayer.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    void MeleeAtack()
    {
        //La funcion no debe hacer nada si no puede atacar
        if(canAttack == false)
        {
            return;
        }
        if(Vector2.Distance(transform.position, player.position) <= attackDistance)
        {
            anim.SetTrigger("Attack");
            Debug.Log("Te quemo con el cigarro");
            StartCoroutine(CRT_AttackCooldown());
        }
    }
    IEnumerator CRT_AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackDistance);

    }
}

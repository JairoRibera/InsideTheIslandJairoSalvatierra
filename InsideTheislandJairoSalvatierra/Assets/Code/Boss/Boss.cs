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
    public bool canMove = true;//para activar o desactivar el movimiento del boss
    [Header("Fase 2")]
    public float jumpForceX = 15f;
    public float jumpForceY = 5f;
    public bool canJumpAttack = true;
    public float jumpAttackCooldown = .5f;
    public int minJumpTime = 3;
    public int maxJumpTime = 4;
    private float jumpAttackTimer;

    [Header("Fase3")]
    public Rigidbody2D projectilPrefab;
    public float shootForce = 15;
    public Transform shootPoint;
    public float shootCooldown = .5f;
    private float shootTimer = 0;
    public float shootDistance = 3f;//Distancia minima para disparar
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
            case 0://Fase 1
                MeleeAtack();
                //va hacia el jugador y ataca melee
                break;
            case 1://Fase 2: Puede atacar a melee o hacer el ataque salto
                if(jumpAttackTimer > 0f)
                {
                    jumpAttackTimer -= Time.deltaTime;
                }
                else
                {
                    JumpAttack();
                }
                if(canJumpAttack == true)
                {
                    MeleeAtack();
                }

                break;
            case 2://Fase 3
                //calculamos distancia entre los 2
                float _distance = Vector2.Distance(transform.position, player.position);
                if (_distance > shootDistance)
                {
                    if (shootTimer > 0f)
                    {
                        shootTimer -= Time.deltaTime;
                    }
                    else if (canJumpAttack == true)
                    {
                        Shoot();
                    }
                }
                else
                {
                    if (canJumpAttack == true)
                    {
                        MeleeAtack();
                    }
                }
                if (jumpAttackTimer > 0f)
                {
                    jumpAttackTimer -= Time.deltaTime;
                }
                else
                {
                    JumpAttack();
                }
                
                break;
        }

        
    }
    private void FixedUpdate()
    {
        if(canMove == true)
        {
            ChasePlayer();
        }
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

    void JumpAttack()
    {
        if(canJumpAttack == false)
        {
            return;
        }

        canMove = false;
        canJumpAttack = false;
        if(player.position.x > transform.position.x)
        {
            rb.AddForce(new Vector2(jumpForceX, jumpForceY), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(-jumpForceX, jumpForceY), ForceMode2D.Impulse);
        }
      

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground")) => Esto es para hacer lo mismo que un CompareTag pero con una layer
        if (collision.collider.CompareTag("Ground") == true && canJumpAttack == false)
        {
            anim.SetTrigger("JumpAttack");
            StartCoroutine(CRT_JumpAttackCooldown());
            rb.velocity = Vector2.zero;
            jumpAttackTimer = Random.Range(minJumpTime, maxJumpTime);
        }
    }
    IEnumerator CRT_JumpAttackCooldown()
    {
        yield return new WaitForSeconds(jumpAttackCooldown);
        canJumpAttack = true;
        canMove = true;
    }

    void Shoot()
    {
        shootTimer = shootCooldown;
        Rigidbody2D _projectil = Instantiate(projectilPrefab, shootPoint.position, shootPoint.rotation);
        //calcula la dirección del personaje
        Vector2 _dirToPlayer = player.position - transform.position;
        //el normalize hace que la velocidad no varie independientemente de la distancia
        _projectil.AddForce(_dirToPlayer.normalized * shootForce, ForceMode2D.Impulse);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, shootDistance);

    }
}

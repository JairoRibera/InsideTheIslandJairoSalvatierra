using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float dashForce;
    public float dashDuration = 0.25f;
    public bool canMove = true;
    private float input;
    public float knockbackeForce = 5f;
    public float knockbackDuration = .25f;
    public float moveSpeed;
    public Rigidbody2D _rB;
    public bool _isGrounded;
    public Transform groundPoint;
    public LayerMask whatIsGround;
    public float jumpForce;
    public bool _canDoubleJump;
    public GameObject Tramp;
    public Transform trampPoint;
    public bool canInteract = false;
    public GameObject bullet;
    public Transform bulletPoint;
    public float bulletSpeed;
    public float cooldownTime;
    float lastShoot;
    float lastTramp;
    public float cooldownTimeTramp;
    // Start is called before the first frame update
    void Start()
    {
        _rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (input != 0f)
        {
            if (input > 0f)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
        
        _isGrounded = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);

        //Si pulsamos el botón de salto
        if (Input.GetButtonDown("Jump"))
        {
            //Si el jugador está en el suelo
            if (_isGrounded)
            {
                //El jugador salta, manteniendo su velocidad en X, y aplicamos la fuerza de salto
                _rB.velocity = new Vector2(_rB.velocity.x, jumpForce);
                
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            putTramp();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            bulletShoot();
            
        }
            
        
    }
    private void FixedUpdate()
    {
        if (canMove == true)
        {
            _rB.velocity = new Vector2(input * moveSpeed, _rB.velocity.y);

        }
    }
    void Dash()
    {
        if (_isGrounded)
        {
            canMove = false;
            _rB.velocity = new Vector2(0, _rB.velocity.y);
            _rB.AddForce(transform.right * dashForce, ForceMode2D.Impulse);
            StartCoroutine(CRT_CancelDash());
        }
        
    }
    IEnumerator CRT_CancelDash()
    {
        //Esto cancela el movimiento mientras estamos haciendo el dash
        yield return new WaitForSeconds(dashDuration);
        canMove = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") == true)
        {
            //Se puede acceder a la posicion en x del objeto contra el que ha chocado usando el collision.collider
            ApplyKnockBack(collision.collider.transform.position.x);
        }
        if (collision.collider.CompareTag("Enemy2") == true)
        {
            //Se puede acceder a la posicion en x del objeto contra el que ha chocado usando el collision.collider
            ApplyKnockBack(collision.collider.transform.position.x);
        }

    }
    public void ApplyKnockBack(float _xPosition)
    {
        canMove = false;
        //Hacemos que la velocidad en X sea 
        _rB.velocity = new Vector2(0, _rB.velocity.y);
        //Dependiendo de si el objeto esta en la derecha o izquierda añadira un empujon en otra direccion
        if (transform.position.x < _xPosition)
        {
            _rB.AddForce(new Vector2(-1, 0.75f) * knockbackeForce, ForceMode2D.Impulse);
        }
        else
        {
            _rB.AddForce(new Vector2(1, 0.75f) * knockbackeForce, ForceMode2D.Impulse);
        }

        StartCoroutine(CRT_CancelKnockbak());
    }

    public IEnumerator CRT_CancelKnockbak()
    {
        yield return new WaitForSeconds(knockbackDuration);
        canMove = true;
    }
    private void putTramp()
    {
        if (_isGrounded)
        {
            if (Time.time - lastShoot < cooldownTimeTramp)
                return;
            lastShoot = Time.time;
            //StartCoroutine(CooldownCo());
            Instantiate(Tramp, trampPoint.transform.position, trampPoint.transform.rotation);
        }
            
    }

    private void bulletShoot()
    {
        if (Time.time - lastTramp < cooldownTime)
            return;
        lastTramp = Time.time;
        Instantiate(bullet, bulletPoint.transform.position, bulletPoint.rotation);
    }
}

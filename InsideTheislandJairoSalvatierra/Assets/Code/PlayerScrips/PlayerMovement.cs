using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool seeLeft = true;
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
    public bool _canDoubleJump = false;
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
    private bool __isDead;
    public Bullet _bReference;
    public static PlayerMovement instance;
    public float noMoveLenght;
    private float noMoveCount;
    public bool desbloqueado = false;
    private PlayerHealthController _pHReference;
    private Animator _anim;
    public float TiempoDisparo;
    public float UltimoDisparo;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerHealthController>();
        _rB = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        
    }


    // Update is called once per frame
    void Update()
    {
       

        if (noMoveCount <= 0 && canMove)
        {
            //_rB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), _rB.velocity.y).normalized * moveSpeed;
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

            ////Si pulsamos el botón de salto
            //if (Input.GetButtonDown("Jump") && _isGrounded)
            //{
            //    Debug.Log("Entra aqui");
            //    ////Si el jugador está en el suelo
            //    //if (_isGrounded)
            //    //{
            //    //El jugador salta, manteniendo su velocidad en X, y aplicamos la fuerza de salto
            //    //_rB.velocity = new Vector2(_rB.velocity.x, jumpForce);
            //    //El jugador salta, manteniendo su velocidad en X, y aplicamos la fuerza de salto
            //    _rB.velocity = new Vector2(_rB.velocity.x, jumpForce);

            //    //}
            //}

            //Si pulsamos el botón de salto
            if (Input.GetButtonDown("Jump"))
            {
                //Si el jugador está en el suelo
                if (_isGrounded)
                {
                    //El jugador salta, manteniendo su velocidad en X, y aplicamos la fuerza de salto
                    _rB.velocity = new Vector2(_rB.velocity.x, jumpForce);
                    ////Llamamos al método del Singleton de AudioManager que reproduce el sonido
                    AudioManager.audioMReference.PlaySFX(7);
                    ////Una vez en el suelo, reactivamos la posibilidad de doble salto
                    _canDoubleJump = true;
                }

                ////Si el jugador no está en el suelo
                //else
                //{
                //    //Si canDoubleJump es verdadera
                if (_canDoubleJump == true && desbloqueado == true && _isGrounded == false)
               {
                  _rB.velocity = new Vector2(_rB.velocity.x, jumpForce);
                    AudioManager.audioMReference.PlaySFX(7);
                    _canDoubleJump = false;
                }
                //}
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
                //if (Time.time > TiempoDisparo + UltimoDisparo)
                //{
                //    UltimoDisparo = Time.time;
                //    _anim.SetTrigger("shoot");
                //    Invoke(nameof(bulletShoot), TiempoDisparo);
                //}
                bulletShoot();
            }
        }
        else
            noMoveCount -= Time.deltaTime;
        _anim.SetFloat("moveSpeed", Mathf.Abs(_rB.velocity.x));
        _anim.SetBool("isGrounded", _isGrounded);

    }
    private void FixedUpdate()
    {
        if (canMove == true)
        {
            _rB.velocity = new Vector2(input * moveSpeed, _rB.velocity.y);

        }
        //StartCoroutine(pUReferenece.normalJumpCo());
        //StartCoroutine(pUReferenece.normalShootCo());
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
        //Si el que colisiona contra el jugador es una plataforma
        if (collision.gameObject.CompareTag("Platform"))
            //El jugador pasa a ser hijo de la plataforma
            transform.parent = collision.transform;
    }
    public void ApplyKnockBack(float _xPosition)
    {
        canMove = false;
        //Hacemos que la velocidad en X sea 
        _rB.velocity = new Vector2(0, _rB.velocity.y);
        //Dependiendo de si el objeto esta en la derecha o izquierda añadira un empujon en otra direccion
        if (transform.position.x < _xPosition + 0.3f)
        {
            _rB.AddForce(new Vector2(-1, 0.75f) * knockbackeForce, ForceMode2D.Impulse);
        }
        else if(transform.position.x >= _xPosition + 0.3f)
        {
            _rB.AddForce(new Vector2(1, 0.75f) * knockbackeForce, ForceMode2D.Impulse);
        }
        if (gameObject.activeSelf)
        {
            StartCoroutine(CRT_CancelKnockbak());

        }

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
        AudioManager.audioMReference.PlaySFX(0);
        Instantiate(bullet, bulletPoint.transform.position, bulletPoint.rotation);

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            StartCoroutine(normalSJ());
        }
        if (collision.CompareTag("Pluma"))
        {
            if (_canDoubleJump == true)
            {
                //        //El jugador salta, manteniendo su velocidad en X, y aplicamos la fuerza de salto
                _rB.velocity = new Vector2(_rB.velocity.x, jumpForce);
                //        //Llamamos al método del Singleton de AudioManager que reproduce el sonido
                //        AudioManager.audioMReference.PlaySFX(10);
                //        //Hacemos que no se pueda volver a saltar de nuevo
                _canDoubleJump = false;
            }

        }
    }
    //Método para conocer cuando dejamos de colisionar contra un objeto
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Si el objeto con el que dejamos de colisionar es una plataforma
        if (collision.gameObject.CompareTag("Platform"))
            //El jugador deja de tener padre
            transform.parent = null;
    }
    public IEnumerator normalSJ()
    {
        yield return new WaitForSeconds(10);
        jumpForce = 8.5f;
        _bReference.damage = 2f;
        _canDoubleJump = false;
    }
    public void normalStats()
    {
        jumpForce = 8.5f;
        _bReference.damage = 2f;
        _canDoubleJump = false;
    }
    public void InitializaNoInput()
    {
        noMoveCount = noMoveLenght;
        _rB.velocity = Vector2.zero;
    }
    public void doblueJump()
    {
        desbloqueado = true;
        StartCoroutine(doblesaltoCo());
    }
    private IEnumerator doblesaltoCo()
    {
        yield return new WaitForSeconds(7);
        desbloqueado = false; 

    }

}

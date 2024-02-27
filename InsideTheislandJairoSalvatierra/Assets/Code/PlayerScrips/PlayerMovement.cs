using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rb;
    private bool _isGrounded;
    public Transform groundPoint;
    public LayerMask whatIsGround;
    public float jumpForce;
    public float knockBackLength; 
    private float _knockBackCounter; 
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, _rb.velocity.y);
        _isGrounded = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);

        //Si pulsamos el botón de salto
        if (Input.GetButtonDown("Jump"))
        {
            //Si el jugador está en el suelo
            if (_isGrounded)
            {
                //El jugador salta, manteniendo su velocidad en X, y aplicamos la fuerza de salto
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
                
            }
           
        }
    }
    
}

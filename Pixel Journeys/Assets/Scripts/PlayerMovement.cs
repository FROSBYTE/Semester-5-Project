using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundPoint;
    

    private Rigidbody2D rb;
    private Vector2 velocity;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool isGround;
    private bool jumpInput;
    private bool doubleJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIsGrounded();
        horizontalMovement();
        Jump();
        animationController();

        if(rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void animationController()
    {
        animator.SetBool("isGrounded", isGround);
        animator.SetFloat("isMoving", Mathf.Abs(rb.velocity.x));
    }

    private void horizontalMovement()
    {
        float xInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(xInput,rb.velocity.y);
    }

    private void UpdateIsGrounded()
    {
        isGround = Physics2D.OverlapCircle(groundPoint.position, 0.1f, groundLayer);

        if (isGround)
        {
            doubleJump = true;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpInput = true;
        }

        if (jumpInput)
        {
            jumpInput = false;

            if(isGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else
            {
                if (doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    doubleJump = false;
                }
            }
        }
    } 
}

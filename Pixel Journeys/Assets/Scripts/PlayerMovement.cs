using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public Rigidbody2D rb;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float knockbackLength;
    [SerializeField] float knockbackForceX;
    [SerializeField] float knockbackForceY;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundPoint;
    [SerializeField] float bounceForce;

    private float knockbackCounter;
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

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (knockbackCounter <= 0)
        {
            UpdateIsGrounded();
            horizontalMovement();
            Jump();
            flipPlayer();
        }
        else
        {
            knockbackCounter -= Time.deltaTime;
            if (!spriteRenderer.flipX)
            {
                rb.velocity = new Vector2(-knockbackForceX,knockbackForceY);
            }
            else
            {
                rb.velocity = new Vector2(knockbackForceX, knockbackForceY);
            }
        }
            animationController();
    }

    private void flipPlayer()
    {
        if (rb.velocity.x < 0)
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
                AudioManager.instance.audioSystem(10);
            }
            else
            {
                if (doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    AudioManager.instance.audioSystem(10);
                    doubleJump = false;
                }
            }
        }
    } 
    public void knockback()
    {
        knockbackCounter = knockbackLength;
        animator.SetTrigger("isHurt");
    }
    public void bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, bounceForce);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
            transform.parent = other.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        transform.parent = null; 
    }
}

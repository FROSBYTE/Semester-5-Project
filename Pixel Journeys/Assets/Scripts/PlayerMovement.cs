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

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        float xInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(xInput, 0);
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, 0.1f, groundLayer);

        float verticalInput = Input.GetAxisRaw("Jump");

            if (isGrounded && verticalInput > 0)
            {
                rb.velocity = Vector2.up * jumpForce;

            //rb.AddForce(Vector2.up * jumpForce);
            }
    }
}


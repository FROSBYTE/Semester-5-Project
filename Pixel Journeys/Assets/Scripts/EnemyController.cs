using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform rightPos;
    [SerializeField] Transform leftPos;
    [SerializeField] float waitTime;
    [SerializeField] float moveTime;
    [SerializeField] SpriteRenderer spriteRenderer;

    public bool isRight;

    private float waitCount;
    private float moveCount;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        rightPos.parent = null;
        leftPos.parent = null;

        isRight = true;

        moveCount = moveTime;
    }
    // Update is called once per frame
    void Update()
    {
        Patrolling();
    }

    private void Patrolling()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;

            if (isRight)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                spriteRenderer.flipX = true;

                if (transform.position.x > rightPos.position.x)
                {
                    isRight = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                spriteRenderer.flipX = false;

                if (transform.position.x < leftPos.position.x)
                {
                    isRight = true;
                }
            }

            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * 0.5f, waitTime * 1.25f);
            }
            animator.SetBool("isMoving", true);

        }
        else if (waitCount > 0)

        {
            waitCount -= Time.deltaTime;
            rb.velocity = new Vector2(0, rb.velocity.y);

            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * 0.5f, moveTime * 1.25f);
            }
            animator.SetBool("isMoving", false);
        }
    }
}

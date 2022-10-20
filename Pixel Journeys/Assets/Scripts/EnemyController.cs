using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform rightPos;
    [SerializeField] Transform leftPos;

    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        rightPos.parent = null;
        leftPos.parent = null;

        isRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            rb.velocity = new Vector2(moveSpeed,rb.velocity.y);

            if(transform.position.x > rightPos.position.x)
            {
                isRight = false;
            }
           
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);

            if (transform.position.x < leftPos.position.x)
            {
                isRight = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] float moveSpeed;
    [SerializeField] int currenPoint;

    [SerializeField] Transform platform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, points[currenPoint].position, moveSpeed * Time.deltaTime);
        
        if(Vector3.Distance(platform.position, points[currenPoint].position) < 0.05f)
        {
            currenPoint++;

            if(currenPoint >= points.Length)
            {
                currenPoint = 0;
            }
        }
    }
}


//rb.velocity = new Vector2(moveSpeed,rb.velocity.y);
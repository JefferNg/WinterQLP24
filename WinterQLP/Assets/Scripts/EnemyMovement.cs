using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemyMovementSpeed;

    Rigidbody2D rb;

    float startPosX;

    [SerializeField] bool movingRight;
    [SerializeField] float maxDistance;

    [SerializeField] float timeTillWaitingTime;
    [SerializeField] float waitTime;

    float move;
    float moveTimer;
    float restTimer;

    // Start is called before the first frame update
    void Start()
    {
        moveTimer = 0;
        restTimer = 0;
        rb = GetComponent<Rigidbody2D>();
        startPosX = rb.position.x;
        move = enemyMovementSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            return;
        }
        moveTimer += Time.deltaTime;
        if(moveTimer > timeTillWaitingTime)
        {
            restTimer += Time.deltaTime;
            if (restTimer > waitTime)
            {
                moveTimer = 0;
                restTimer = 0;
            }
            return;
        }
        float currentDistance = rb.position.x - startPosX;

        if((currentDistance>maxDistance && movingRight) || (currentDistance < -maxDistance && !movingRight))
        {
            movingRight = !movingRight;
            move *= -1;
        }
        
        rb.MovePosition(new Vector2(transform.position.x + move, transform.position.y));
    }
}

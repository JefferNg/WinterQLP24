using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemyMovementSpeed;

    Rigidbody2D rb;

    float startPosX;

    [SerializeField] bool movingRight;
    [SerializeField] float maxDistance;

    float move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosX = rb.position.x;
        move = enemyMovementSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentDistance = rb.position.x - startPosX;

        if((currentDistance>maxDistance && movingRight) || (currentDistance < -maxDistance && !movingRight))
        {
            movingRight = !movingRight;
            move *= -1;
        }
        
        rb.MovePosition(new Vector2(transform.position.x + move, transform.position.y));
    }
}

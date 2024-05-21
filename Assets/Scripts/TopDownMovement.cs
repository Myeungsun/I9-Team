using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private Vector2 movementDirection = Vector2.zero;
    private SpriteRenderer spriteRenderer;
    private Animator animator;   
    private float currentSpeed;
    public float moveSpeed = 200f;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = transform.Find("MainSprite").GetComponent<SpriteRenderer>();
        animator = transform.Find("MainSprite").GetComponent<Animator>();
        currentSpeed = moveSpeed;
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }


    private void Move(Vector2 direction)
    {
        movementDirection = direction;

        if (animator != null)
        {
            bool isMoving = direction.sqrMagnitude > 0;

            animator.SetBool("isMove", isMoving);
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
        FlipCharacter(movementDirection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        
        direction = direction * currentSpeed;
        //Debug.Log(currentSpeed);
        movementRigidbody.velocity = direction;
    }

    private void FlipCharacter(Vector2 direction)  //뒤집기
    {
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void BoostSpeed(float multiplier, float duration)
    {
        Debug.Log("BoostSpeed called with multiplier: " + multiplier + " and duration: " + duration);
        StartCoroutine(SpeedBoostCoroutine(multiplier, duration));
    }

    private IEnumerator SpeedBoostCoroutine(float multiplier, float duration)
    {
        currentSpeed = moveSpeed * multiplier; // 속도 증가
        yield return new WaitForSeconds(duration); // 지정된 시간 동안 대기
        currentSpeed = moveSpeed; // 원래 속도로 복귀
    }
}

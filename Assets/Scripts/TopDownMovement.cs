using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private Vector2 movementDirection = Vector2.zero;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = transform.Find("MainSprite").GetComponent<SpriteRenderer>();
        animator = transform.Find("MainSprite").GetComponent<Animator>();
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
        direction = direction * 200;
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
}

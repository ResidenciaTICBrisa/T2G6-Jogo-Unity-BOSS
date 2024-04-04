using UnityEngine;
using System;

public class MovePlayer : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed = 5f;
    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleAttack();
        UpdateAnimationState();
    }

    private void HandleMovement()
    {
        float horizontalInput = movementJoystick.Direction.x;
        float verticalInput = movementJoystick.Direction.y;

        if (horizontalInput != 0 || verticalInput != 0)
        {
            rb.velocity = new Vector2(horizontalInput * playerSpeed, verticalInput * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity == Vector2.zero)
        {
            animator.SetTrigger("trAttacking");
        }
    }

    private void UpdateAnimationState()
    {
        float x = rb.velocity.x;
        float y = rb.velocity.y;
        animator.SetFloat("MoveX", Math.Abs(x) < Math.Abs(y) ? 0 : x);
        animator.SetFloat("MoveY", Math.Abs(y) < Math.Abs(x) ? 0 : y);
    }
}

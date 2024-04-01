using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private Vector2 lastMoveDirection;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleAttack();
        UpdateAnimationState();
    }

    void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        lastMoveDirection = new Vector2(horizontalInput, verticalInput);
    }

    void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && lastMoveDirection == Vector2.zero)
        {
            animator.SetTrigger("trAttacking");
        } else {
        }
    }

    void UpdateAnimationState()
    {
        animator.SetFloat("MoveX", lastMoveDirection.x);
        animator.SetFloat("MoveY", lastMoveDirection.y);
    }
}

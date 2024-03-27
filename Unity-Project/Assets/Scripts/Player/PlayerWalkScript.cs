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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        lastMoveDirection = new Vector2(horizontalInput, verticalInput);
        
        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        animator.SetFloat("MoveX", lastMoveDirection.x);
        animator.SetFloat("MoveY", lastMoveDirection.y);
    }
}
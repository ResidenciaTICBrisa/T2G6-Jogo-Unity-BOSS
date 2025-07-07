using System.Collections;
using UnityEngine;

/// <summary>
/// Old Man NPC that patrols between two points and stops to talk with the player.
/// Inherits dialogue functionality from NPCScript and adds movement behavior.
/// </summary>
public class OldManScript : NPCScript
{
    [Header("Movement")]
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float speed = 2f;

    [Header("Pause Settings")]
    [SerializeField] private float pauseInterval = 8f;
    [SerializeField] private float pauseDuration = 4f;

    private Rigidbody2D rb;
    private Animator animator;
    private Transform currentTargetPoint;
    private float timeSinceLastPause = 0f;
    private bool isMovementStopped = false;
    private Vector2 velocityBeforePause;

    private const float DESTINATION_THRESHOLD = 1f;
    private const string WALKING_ANIMATION_PARAMETER = "isWalking";

    protected virtual void Start()
    {
        InitializeComponents();
        StartMovementToPoint(pointB.transform);
    }

    protected virtual void Update()
    {
        base.HandleDialogueInput();
        
        if (isMovementStopped)
            return;

        HandleMovement();
        HandlePeriodicPause();
    }

    private void InitializeComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    private void StartMovementToPoint(Transform targetPoint)
    {
        currentTargetPoint = targetPoint;
        SetMovementVelocity();
        SetWalkingAnimation(true);
    }

    private void HandleMovement()
    {
        if (HasReachedDestination())
        {
            SwitchToOppositePoint();
        }
    }

    private bool HasReachedDestination()
    {
        float distanceToTarget = Mathf.Abs(transform.position.x - currentTargetPoint.position.x);
        return distanceToTarget < DESTINATION_THRESHOLD;
    }

    private void SwitchToOppositePoint()
    {
        if (currentTargetPoint == pointB.transform)
        {
            StartMovementToPoint(pointA.transform);
        }
        else
        {
            StartMovementToPoint(pointB.transform);
        }
        
        FlipSprite();
    }

    private void FlipSprite()
    {
        transform.localRotation *= Quaternion.Euler(0, 180, 0);
    }

    private void SetMovementVelocity()
    {
        float direction = currentTargetPoint == pointB.transform ? 1f : -1f;
        rb.velocity = new Vector2(speed * direction, 0);
    }

    private void HandlePeriodicPause()
    {
        timeSinceLastPause += Time.deltaTime;
        
        if (timeSinceLastPause >= pauseInterval)
        {
            timeSinceLastPause = 0f;
            StartCoroutine(PauseMovement());
        }
    }

    private IEnumerator PauseMovement()
    {
        StopMovement();
        yield return new WaitForSeconds(pauseDuration);
        
        if (!isMovementStopped)
        {
            ResumeMovement();
        }
    }

    private void StopMovement()
    {
        SetWalkingAnimation(false);
        velocityBeforePause = rb.velocity;
        rb.velocity = Vector2.zero;
    }

    private void ResumeMovement()
    {
        SetWalkingAnimation(true);
        rb.velocity = velocityBeforePause;
    }

    private void SetWalkingAnimation(bool isWalking)
    {
        if (animator != null)
            animator.SetBool(WALKING_ANIMATION_PARAMETER, isWalking);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        base.OnTriggerEnter2D(other);
        StopAllMovement();
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        base.OnTriggerExit2D(other);
        ResumeAllMovement();
    }

    private void StopAllMovement()
    {
        isMovementStopped = true;
        StopMovement();
    }

    private void ResumeAllMovement()
    {
        isMovementStopped = false;
        SetWalkingAnimation(true);
        SetMovementVelocity();
    }
}

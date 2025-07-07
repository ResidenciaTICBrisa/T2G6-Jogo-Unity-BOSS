using System.Collections;
using UnityEngine;

/// <summary>
/// Boy NPC that randomly patrols within defined boundaries.
/// Inherits dialogue functionality from NPCScript and adds random movement behavior.
/// </summary>
public class Boy2Script : NPCScript
{
    [Header("Movement")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 2f;
    [SerializeField] private int facingDirection = 1;

    [Header("Patrol Boundaries")]
    [SerializeField] private float leftPatrolX;
    [SerializeField] private float rightPatrolX;
    [SerializeField] private float upPatrolY;
    [SerializeField] private float bottomPatrolY;

    [Header("Timing")]
    [SerializeField] private float minPauseTime = 1f;
    [SerializeField] private float maxPauseTime = 3f;
    [SerializeField] private float minWalkTime = 2f;
    [SerializeField] private float maxWalkTime = 5f;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    private float currentStateTimer;
    private float targetStateTime;
    private bool isFlipping;
    private bool isWalking = true;

    private const float FLIP_DURATION = 0.5f;
    private const string WALKING_LEFT_ANIMATION_PARAMETER = "isWalkingLeft";

    protected virtual void Start()
    {
        InitializeComponents();
        InitializeMovementState();
    }

    protected virtual void Update()
    {
        base.HandleDialogueInput();

        if (playerIsClose)
        {
            HandlePlayerInteraction();
            return;
        }

        UpdateMovementTimer();
        HandlePatrolBoundaries();
        ApplyMovement();
    }

    private void InitializeComponents()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
            
        dialogueText.text = string.Empty;
    }

    private void InitializeMovementState()
    {
        SetRandomStateTime();
        SetWalkingAnimation(isWalking);
    }

    private void HandlePlayerInteraction()
    {
        StopMovement();
        SetWalkingAnimation(false);
    }

    private void UpdateMovementTimer()
    {
        currentStateTimer += Time.deltaTime;

        if (currentStateTimer >= targetStateTime)
        {
            ToggleMovementState();
        }
    }

    private void HandlePatrolBoundaries()
    {
        if (ShouldFlipHorizontally() && !isFlipping)
        {
            StartCoroutine(FlipHorizontally());
        }
    }

    private bool ShouldFlipHorizontally()
    {
        return transform.position.x > rightPatrolX || transform.position.x < leftPatrolX;
    }

    private void ApplyMovement()
    {
        if (isWalking)
        {
            rb.velocity = Vector2.right * facingDirection * speed;
        }
    }

    private IEnumerator FlipHorizontally()
    {
        isFlipping = true;
        transform.Rotate(0, 180, 0);
        facingDirection *= -1;
        yield return new WaitForSeconds(FLIP_DURATION);
        isFlipping = false;
    }

    private void ToggleMovementState()
    {
        isWalking = !isWalking;
        SetWalkingAnimation(isWalking);
        
        if (!isWalking)
        {
            StopMovement();
        }
        else
        {
            StartMovement();
        }
        
        SetRandomStateTime();
        ResetTimer();
    }

    private void SetWalkingAnimation(bool walking)
    {
        if (animator != null)
            animator.SetBool(WALKING_LEFT_ANIMATION_PARAMETER, walking);
    }

    private void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }

    private void StartMovement()
    {
        rb.velocity = Vector2.right * facingDirection * speed;
    }

    private void SetRandomStateTime()
    {
        targetStateTime = isWalking 
            ? Random.Range(minWalkTime, maxWalkTime) 
            : Random.Range(minPauseTime, maxPauseTime);
    }

    private void ResetTimer()
    {
        currentStateTimer = 0f;
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        base.OnTriggerExit2D(other);
        
        if (!isWalking)
        {
            ToggleMovementState();
        }
    }
}

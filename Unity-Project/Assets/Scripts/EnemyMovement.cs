using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Controls enemy AI behavior including movement, combat, and health management.
/// Handles enemy awareness, pathfinding, attacking, and death states.
/// </summary>
public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 3f;

    [Header("Combat")]
    [SerializeField] private float attackDuration = 3f;
    [SerializeField] private float attackRange = 2f;

    [Header("Health")]
    [SerializeField] private int maxHealth = 100;

    // Core Components
    private Rigidbody2D enemyRigidbody;
    private PlayerAwareness playerAwarenessController;
    private Animator enemyAnimator;
    private Animator attackEffectAnimator;
    private Animator healthBarAnimator;
    private BoxCollider2D enemyCollider;

    // Movement and Targeting
    private Vector2 targetDirection;
    private GameObject playerObject;
    private PlayerController playerController;

    // Combat State
    private float attackTimer = 3f;
    private bool isAttacking = false;
    private int currentHealth;

    // Health Constants
    private const int FULL_HEALTH = 100;
    private const int MEDIUM_HEALTH = 66;
    private const int LOW_HEALTH = 33;
    private const int NO_HEALTH = 0;
    private const float DESTRUCTION_DELAY = 2f;

    // Animation Parameters
    private const string MOVE_X_PARAMETER = "MoveX";
    private const string MOVE_Y_PARAMETER = "MoveY";
    private const string STOP_TRIGGER = "Stop";
    private const string DOWN_TRIGGER = "Down";
    private const string DEAD_TRIGGER = "Dead";
    private const string HP_PARAMETER = "Hp";
    private const string ATTACK_DOWN_TRIGGER = "TriggerAttackDown";
    private const string ATTACK_UP_TRIGGER = "TriggerAttackUp";
    private const string ATTACK_LEFT_TRIGGER = "TriggerAttackLeft";
    private const string ATTACK_RIGHT_TRIGGER = "TriggerAttackRight";

    // Movement Constants
    private const float MOVEMENT_ANIMATION_DELAY = 2f;

    private void Awake()
    {
        InitializeComponents();
        InitializeHealth();
        CachePlayerReference();
    }

    private void FixedUpdate()
    {
        if (IsEnemyDead())
        {
            HandleDeath();
            return;
        }

        if (IsPlayerDeadOrEnemyDead())
            return;

        UpdateAttackTimer();
        
        if (isAttacking)
            return;

        UpdateTargetDirection();
        StartCoroutine(HandleMovement());
        TryAttackPlayer();
    }

    #region Initialization

    private void InitializeComponents()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwareness>();
        enemyAnimator = GetComponent<Animator>();
        enemyCollider = GetComponent<BoxCollider2D>();

        InitializeChildComponents();
    }

    private void InitializeChildComponents()
    {
        if (transform.childCount > 0)
            attackEffectAnimator = transform.GetChild(0).GetComponent<Animator>();

        if (transform.childCount > 1)
            healthBarAnimator = transform.GetChild(1).GetComponent<Animator>();
    }

    private void InitializeHealth()
    {
        currentHealth = maxHealth;
    }

    private void CachePlayerReference()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            playerController = playerObject.GetComponent<PlayerController>();
    }

    #endregion

    #region State Checks

    private bool IsEnemyDead()
    {
        return currentHealth <= NO_HEALTH;
    }

    private bool IsPlayerDeadOrEnemyDead()
    {
        return (playerController != null && playerController.CurrentHealth <= NO_HEALTH) || 
               currentHealth <= NO_HEALTH;
    }

    private bool IsPlayerInAttackRange()
    {
        if (playerAwarenessController?._player == null)
            return false;

        float distanceToPlayer = (playerAwarenessController._player.position - transform.position).magnitude;
        return distanceToPlayer < attackRange;
    }

    #endregion

    #region Movement

    private void UpdateTargetDirection()
    {
        if (playerAwarenessController?.awareOfPlayer == true)
        {
            targetDirection = playerAwarenessController.directionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }

    private IEnumerator HandleMovement()
    {
        if (ShouldStopMovement())
        {
            StopMovement();
            yield return null;
        }
        else
        {
            MoveTowardsTarget();
            yield return new WaitForSeconds(MOVEMENT_ANIMATION_DELAY);
        }
    }

    private bool ShouldStopMovement()
    {
        return targetDirection == Vector2.zero;
    }

    private void StopMovement()
    {
        enemyRigidbody.velocity = Vector2.zero;
        SetMovementAnimation(0f, 0f);
        enemyAnimator.SetTrigger(STOP_TRIGGER);
    }

    private void MoveTowardsTarget()
    {
        float x = targetDirection.x;
        float y = targetDirection.y;

        float animX = Mathf.Abs(x) < Mathf.Abs(y) ? 0 : x;
        float animY = Mathf.Abs(y) < Mathf.Abs(x) ? 0 : y;

        SetMovementAnimation(animX, animY);
        enemyRigidbody.velocity = targetDirection * movementSpeed;

        if (animY < 0)
        {
            enemyAnimator.SetTrigger(DOWN_TRIGGER);
        }
    }

    private void SetMovementAnimation(float moveX, float moveY)
    {
        enemyAnimator.SetFloat(MOVE_X_PARAMETER, moveX);
        enemyAnimator.SetFloat(MOVE_Y_PARAMETER, moveY);
    }

    #endregion

    #region Combat

    private void TryAttackPlayer()
    {
        if (CanAttack())
        {
            PerformAttack();
        }
    }

    private bool CanAttack()
    {
        return !isAttacking && IsPlayerInAttackRange();
    }

    private void PerformAttack()
    {
        isAttacking = true;
        DetermineAttackDirection();
        ResetMovementAnimation();
        StopMovement();
    }

    private void DetermineAttackDirection()
    {
        float moveX = enemyAnimator.GetFloat(MOVE_X_PARAMETER);
        float moveY = enemyAnimator.GetFloat(MOVE_Y_PARAMETER);

        if (IsNotMoving(moveX, moveY))
        {
            TriggerAttackAnimations(ATTACK_DOWN_TRIGGER);
        }
        else if (moveX > 0)
        {
            TriggerAttackAnimations(ATTACK_RIGHT_TRIGGER);
        }
        else if (moveX < 0)
        {
            TriggerAttackAnimations(ATTACK_LEFT_TRIGGER);
        }
        else if (moveY > 0)
        {
            TriggerAttackAnimations(ATTACK_UP_TRIGGER);
        }
        else if (moveY < 0)
        {
            TriggerAttackAnimations(ATTACK_DOWN_TRIGGER);
        }
    }

    private bool IsNotMoving(float moveX, float moveY)
    {
        return Mathf.Approximately(moveX, 0f) && Mathf.Approximately(moveY, 0f);
    }

    private void TriggerAttackAnimations(string attackTrigger)
    {
        enemyAnimator.SetTrigger(attackTrigger);
        
        if (attackEffectAnimator != null)
            attackEffectAnimator.SetTrigger(attackTrigger);
    }

    private void ResetMovementAnimation()
    {
        SetMovementAnimation(0f, 0f);
    }

    private void UpdateAttackTimer()
    {
        if (!isAttacking)
            return;

        attackTimer += Time.deltaTime;
        
        if (attackTimer >= attackDuration)
        {
            EndAttack();
        }
    }

    private void EndAttack()
    {
        attackTimer = 0f;
        isAttacking = false;
    }

    #endregion

    #region Health System

    public void ReceiveDamage()
    {
        Debug.Log("Enemy received damage");

        int newHealth = CalculateNewHealth();
        SetHealth(newHealth);

        if (IsEnemyDead())
        {
            HandleDeath();
        }

        Debug.Log($"Enemy health: {currentHealth}");
    }

    private int CalculateNewHealth()
    {
        return currentHealth switch
        {
            FULL_HEALTH => MEDIUM_HEALTH,
            MEDIUM_HEALTH => LOW_HEALTH,
            LOW_HEALTH => NO_HEALTH,
            _ => currentHealth
        };
    }

    private void SetHealth(int newHealth)
    {
        currentHealth = newHealth;
        UpdateHealthBarAnimation();
    }

    private void UpdateHealthBarAnimation()
    {
        if (healthBarAnimator != null)
        {
            healthBarAnimator.SetInteger(HP_PARAMETER, currentHealth);
        }
    }

    private void HandleDeath()
    {
        if (currentHealth <= NO_HEALTH)
        {
            TriggerDeathAnimation();
            DisableCollider();
            ScheduleDestruction();
            Debug.Log("Enemy died");
        }
        else
        {
            Destroy(gameObject, DESTRUCTION_DELAY);
        }
    }

    private void TriggerDeathAnimation()
    {
        enemyAnimator.SetTrigger(DEAD_TRIGGER);
    }

    private void DisableCollider()
    {
        if (enemyCollider != null)
            enemyCollider.enabled = false;
    }

    private void ScheduleDestruction()
    {
        // Death animation will play, object destroyed after delay
    }

    #endregion

    #region Public Properties

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;
    public bool IsAttacking => isAttacking;
    public bool IsDead => currentHealth <= NO_HEALTH;
    public float AttackRange => attackRange;

    #endregion
}

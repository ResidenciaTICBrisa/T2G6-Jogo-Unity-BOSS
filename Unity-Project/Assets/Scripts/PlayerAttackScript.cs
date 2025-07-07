using UnityEngine;

/// <summary>
/// Handles attack collisions and damage dealing for both player and enemy attacks.
/// Manages attack timing, knockback effects, and damage application to targets.
/// </summary>
public class AttackController : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private float attackDuration = 1f;
    [SerializeField] private float knockbackForce = 10000000f;

    private float attackTimer = 0f;
    private bool isAttacking = false;

    // Tags
    private const string PLAYER_TAG = "Player";
    private const string ENEMY_TAG = "Enemy";
    private const string ROBOT_T2_NAME = "RobotT2";

    private void FixedUpdate()
    {
        UpdateAttackTimer();
    }

    #region Attack Timer Management

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

    #region Collision Detection

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Attack collision detected from: {GetAttackerTag()}");
        
        if (isAttacking)
            return;

        if (IsValidAttackTarget(other))
        {
            DealDamageToTarget(other);
            StartAttack();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsEnemyTarget(other))
        {
            ApplyKnockbackToTarget(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsValidTarget(other))
        {
            StopTargetMovement(other);
        }
    }

    #endregion

    #region Attack Logic

    private bool IsValidAttackTarget(Collider2D target)
    {
        string attackerTag = GetAttackerTag();
        
        return (IsPlayerAttackingEnemy(target, attackerTag) || 
                IsEnemyAttackingPlayer(target, attackerTag));
    }

    private bool IsPlayerAttackingEnemy(Collider2D target, string attackerTag)
    {
        return target.CompareTag(ENEMY_TAG) && attackerTag == PLAYER_TAG;
    }

    private bool IsEnemyAttackingPlayer(Collider2D target, string attackerTag)
    {
        return target.CompareTag(PLAYER_TAG) && attackerTag == ENEMY_TAG;
    }

    private void DealDamageToTarget(Collider2D target)
    {
        string attackerTag = GetAttackerTag();
        
        if (IsPlayerAttackingEnemy(target, attackerTag))
        {
            DealDamageToEnemy(target);
        }
        else if (IsEnemyAttackingPlayer(target, attackerTag))
        {
            DealDamageToPlayer(target);
        }
    }

    private void DealDamageToEnemy(Collider2D enemy)
    {
        if (IsSpecialRobot(enemy))
        {
            DealDamageToSpecialRobot(enemy);
        }
        else
        {
            DealDamageToRegularEnemy(enemy);
        }
    }

    private bool IsSpecialRobot(Collider2D enemy)
    {
        return enemy.name == ROBOT_T2_NAME;
    }

    private void DealDamageToSpecialRobot(Collider2D robot)
    {
        var redMovement = robot.GetComponent<RedMovement>();
        if (redMovement != null)
        {
            redMovement.ReceiveDamage();
            Debug.Log("Damaged special robot");
        }
    }

    private void DealDamageToRegularEnemy(Collider2D enemy)
    {
        var enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.ReceiveDamage();
            Debug.Log("Damaged regular enemy");
        }
    }

    private void DealDamageToPlayer(Collider2D player)
    {
        var playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.ReceiveDamage();
            Debug.Log("Damaged player");
        }
    }

    private void StartAttack()
    {
        isAttacking = true;
    }

    #endregion

    #region Knockback System

    private void ApplyKnockbackToTarget(Collider2D target)
    {
        var targetRigidbody = GetTargetRigidbody(target);
        if (targetRigidbody == null)
            return;

        Vector3 knockbackDirection = CalculateKnockbackDirection(target);
        ApplyKnockbackForce(targetRigidbody, knockbackDirection);
        
        Debug.Log($"Applied knockback: {targetRigidbody.velocity}");
    }

    private Vector3 CalculateKnockbackDirection(Collider2D target)
    {
        Vector3 attackerPosition = GetAttackerPosition();
        Vector3 targetPosition = target.transform.position;
        
        return (targetPosition - attackerPosition).normalized;
    }

    private void ApplyKnockbackForce(Rigidbody2D targetRigidbody, Vector3 direction)
    {
        targetRigidbody.AddForce(direction * knockbackForce, ForceMode2D.Force);
    }

    #endregion

    #region Utility Methods

    private string GetAttackerTag()
    {
        return transform.parent?.tag ?? string.Empty;
    }

    private Vector3 GetAttackerPosition()
    {
        return transform.parent?.position ?? transform.position;
    }

    private bool IsEnemyTarget(Collider2D target)
    {
        return target.CompareTag(ENEMY_TAG);
    }

    private bool IsValidTarget(Collider2D target)
    {
        return target.CompareTag(ENEMY_TAG) || target.CompareTag(PLAYER_TAG);
    }

    private Rigidbody2D GetTargetRigidbody(Collider2D target)
    {
        return target.GetComponent<Rigidbody2D>();
    }

    private void StopTargetMovement(Collider2D target)
    {
        var targetRigidbody = GetTargetRigidbody(target);
        if (targetRigidbody != null)
        {
            targetRigidbody.velocity = Vector2.zero;
        }
    }

    #endregion

    #region Public Properties

    public bool IsAttacking => isAttacking;
    public float AttackDuration => attackDuration;
    public float KnockbackForce => knockbackForce;

    #endregion
}

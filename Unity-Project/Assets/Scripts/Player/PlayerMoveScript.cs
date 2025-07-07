using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles player movement, combat, and health management.
/// Controls player movement via joystick input, attack animations, and health system.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Joystick movementJoystick;
    [SerializeField] private float playerSpeed = 5f;

    [Header("Combat")]
    [SerializeField] private float attackDuration = 0.5f;
    [SerializeField] private Button attackButton;

    [Header("UI")]
    [SerializeField] private GameObject talkPanel;

    [Header("Health")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Animator healthBarAnimator;

    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody;
    public int currentHealth;
    private float attackTimer;
    private bool isAttacking;

    // Health thresholds
    private const int FULL_HEALTH = 100;
    private const int MEDIUM_HEALTH = 66;
    private const int LOW_HEALTH = 33;
    private const int NO_HEALTH = 0;

    // Animation parameter names
    private const string MOVE_X_PARAMETER = "MoveX";
    private const string MOVE_Y_PARAMETER = "MoveY";
    private const string HP_TRIGGER = "Hp";
    private const string ATTACK_DOWN_TRIGGER = "TriggerAttackDown";
    private const string ATTACK_UP_TRIGGER = "TriggerAttackUp";
    private const string ATTACK_LEFT_TRIGGER = "TriggerAttackLeft";
    private const string ATTACK_RIGHT_TRIGGER = "TriggerAttackRight";
    private const string CURRENT_HP_PARAMETER = "currentHp";

    // Scene names
    private const string GROVE_SCENE = "Grove";

    private void Awake()
    {
        InitializeComponents();
        InitializeHealth();
    }

    private void Start()
    {
        SetupHealthBarForGroveScene();
    }

    private void FixedUpdate()
    {
        UpdateAttackTimer();
        
        if (isAttacking) 
            return;

        HandleMovement();
        UpdateMovementAnimation();
    }

    #region Initialization

    private void InitializeComponents()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void InitializeHealth()
    {
        currentHealth = maxHealth;
    }

    private void SetupHealthBarForGroveScene()
    {
        if (!IsCurrentScene(GROVE_SCENE)) 
            return;

        Transform healthBarTransform = GetHealthBarTransform();
        if (healthBarTransform != null)
        {
            healthBarTransform.gameObject.SetActive(true);
            healthBarAnimator = healthBarTransform.GetComponent<Animator>();
        }
    }

    private Transform GetHealthBarTransform()
    {
        return transform.childCount > 1 ? transform.GetChild(1) : null;
    }

    private bool IsCurrentScene(string sceneName)
    {
        return SceneManager.GetActiveScene().name == sceneName;
    }

    #endregion

    #region Movement

    private void HandleMovement()
    {
        if (IsPlayerInDialogue())
        {
            StopMovement();
            return;
        }

        Vector2 movementInput = GetMovementInput();
        ApplyMovement(movementInput);
    }

    private bool IsPlayerInDialogue()
    {
        return talkPanel != null && talkPanel.activeInHierarchy;
    }

    private Vector2 GetMovementInput()
    {
        if (movementJoystick == null) 
            return Vector2.zero;

        return new Vector2(movementJoystick.Direction.x, movementJoystick.Direction.y);
    }

    private void ApplyMovement(Vector2 input)
    {
        playerRigidbody.velocity = input != Vector2.zero ? input * playerSpeed : Vector2.zero;
    }

    private void StopMovement()
    {
        playerRigidbody.velocity = Vector2.zero;
    }

    #endregion

    #region Combat

    public void HandleAttack()
    {
        if (isAttacking) 
            return;

        StartAttack();
        DetermineAttackDirection();
        ResetMovementAnimation();
        StopMovement();
    }

    private void StartAttack()
    {
        isAttacking = true;
        Debug.Log("Player attacking");
    }

    private void DetermineAttackDirection()
    {
        float moveX = playerAnimator.GetFloat(MOVE_X_PARAMETER);
        float moveY = playerAnimator.GetFloat(MOVE_Y_PARAMETER);

        if (IsNotMoving(moveX, moveY))
        {
            TriggerAttackAnimation(ATTACK_DOWN_TRIGGER);
        }
        else if (moveX > 0)
        {
            TriggerAttackAnimation(ATTACK_RIGHT_TRIGGER);
        }
        else if (moveX < 0)
        {
            TriggerAttackAnimation(ATTACK_LEFT_TRIGGER);
        }
        else if (moveY > 0)
        {
            TriggerAttackAnimation(ATTACK_UP_TRIGGER);
        }
        else if (moveY < 0)
        {
            TriggerAttackAnimation(ATTACK_DOWN_TRIGGER);
        }
    }

    private bool IsNotMoving(float moveX, float moveY)
    {
        return Mathf.Approximately(moveX, 0f) && Mathf.Approximately(moveY, 0f);
    }

    private void TriggerAttackAnimation(string triggerName)
    {
        playerAnimator.SetTrigger(triggerName);
    }

    private void ResetMovementAnimation()
    {
        playerAnimator.SetFloat(MOVE_X_PARAMETER, 0);
        playerAnimator.SetFloat(MOVE_Y_PARAMETER, 0);
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
        attackTimer = 0;
        isAttacking = false;
    }

    #endregion

    #region Health System

    public void ReceiveDamage()
    {
        Debug.Log("Player received damage");

        int newHealth = CalculateNewHealth();
        SetHealth(newHealth);

        if (IsPlayerDead())
        {
            HandlePlayerDeath();
        }

        Debug.Log($"Current health: {currentHealth}");
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
            healthBarAnimator.SetInteger("Hp", currentHealth);
        }
    }

    private bool IsPlayerDead()
    {
        return currentHealth <= NO_HEALTH;
    }

    private void HandlePlayerDeath()
    {
        playerAnimator.SetTrigger(HP_TRIGGER);
        Debug.Log("Player died");
    }

    #endregion

    #region Animation

    private void UpdateMovementAnimation()
    {
        Vector2 velocity = playerRigidbody.velocity;
        float absX = Mathf.Abs(velocity.x);
        float absY = Mathf.Abs(velocity.y);

        float moveX = absX < absY ? 0 : velocity.x;
        float moveY = absY < absX ? 0 : velocity.y;

        playerAnimator.SetFloat(MOVE_X_PARAMETER, moveX);
        playerAnimator.SetFloat(MOVE_Y_PARAMETER, moveY);
    }

    #endregion

    #region Public Properties

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;
    public bool IsAttacking => isAttacking;
    public bool IsMoving => playerRigidbody.velocity.magnitude > 0.1f;

    #endregion
}

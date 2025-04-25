using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using System.Data;

public class MovePlayer : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed = 5f;
    private Animator animator;
    private Rigidbody2D rb;
    private float atkTimer = 0f;
    public float atkDuration = 0.5f;
    private bool isAttacking = false;
    public Button atkButton;
    public GameObject talkPanel;
    public int hp = 100;
    public Animator animatorLife;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Scene cena = SceneManager.GetActiveScene();
        if (cena.name == "Grove")
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            animatorLife = gameObject.transform.GetChild(1).GetComponent<Animator>();
            Debug.Log(animatorLife);
        }
    }

    private void FixedUpdate()
    {
        CheckTimer();
        //HandleAttack();
        if (isAttacking == true) return;
        HandleMovement();
        UpdateAnimationState();
    }

    public void ReceiveDamage()
    {
        Debug.Log("damage taken");
        switch (hp)
        {
            case 100:
                hp = 66;
                animatorLife.SetInteger("Hp", 66);
                break;
            case 66:
                hp = 33;
                animatorLife.SetInteger("Hp", 33);
                break;
            case 33:
                hp = 0;
                animatorLife.SetInteger("Hp", 0);
                animator.SetTrigger("Hp");
                Debug.Log("Morri");
                break;
        }
        Debug.Log(hp);
    }

    private void HandleMovement()
    {
        float horizontalInput = movementJoystick.Direction.x;
        float verticalInput = movementJoystick.Direction.y;

        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (!talkPanel.activeInHierarchy)
            {
                rb.velocity = new Vector2(horizontalInput * playerSpeed, verticalInput * playerSpeed);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }

    public void HandleAttack()
    {
        if (/*Input.GetKeyDown(KeyCode.V)*/ isAttacking == false)
        {
            isAttacking = true;
            Debug.Log("Att");
            if (animator.GetFloat("MoveX") == 0 && animator.GetFloat("MoveY") == 0)
            {
                animator.SetTrigger("TriggerAttackDown");

            } else if (animator.GetFloat("MoveX") > 0)
            {
                animator.SetTrigger("TriggerAttackRight");

            } else if (animator.GetFloat("MoveX") < 0)
            {
                animator.SetTrigger("TriggerAttackLeft");

            } else if (animator.GetFloat("MoveY") > 0)
            {
                animator.SetTrigger("TriggerAttackUp");

            } else if (animator.GetFloat("MoveY") < 0)
            {
                animator.SetTrigger("TriggerAttackDown");

            }
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
            rb.velocity = Vector2.zero;
            
        }
        
    }

    private void UpdateAnimationState()
    {
        float x = rb.velocity.x;
        float y = rb.velocity.y;
        animator.SetFloat("MoveX", Math.Abs(x) < Math.Abs(y) ? 0 : x);
        animator.SetFloat("MoveY", Math.Abs(y) < Math.Abs(x) ? 0 : y);
    }

    private void CheckTimer()
    {
        if(isAttacking == true)
        {
            atkTimer += Time.deltaTime;
            if(atkTimer >= atkDuration)
            {
                atkTimer = 0;
                isAttacking = false;
            }
        }
    }
}

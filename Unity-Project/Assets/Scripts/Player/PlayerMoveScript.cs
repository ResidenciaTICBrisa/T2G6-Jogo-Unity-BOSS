using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;




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


/*parte do código para pega e jogar itens
    [Header("Config")]
    List <GameObject> collidingWithList = new List<GameObject>();
    GameObject collidingWith;
    Transform item;
    

    void Update()
    {
        Interact();
    }

    void Interact()
    {
        if(this.collidingWith == null) return;

        if(Input.GetKeyDown(KeyCode.E))
        {
            switch(this.collidingWith.tag)
            {
                case "container":
                    ContainerController container = this.collidingWith.GetComponent<ContainerController>();

                    if(this.item != null && !container.HaveItem())
                    {
                        this.item.position = container.transform.position;
                        this.item.parent = container.transform;
                        container.SetItem(this.item);
                        this.item = null;
                        return;
                    }

                    if(this.item == null && container.HaveItem())
                    {
                        this.item = container.GetItem();
                        this.item.position = this.transform.position;
                        this.item.parent = this.transform;
                        return;
                    }
                    
                    break;
            }
            
        }



    }

 final do código
 */

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckTimer();
        //HandleAttack();
        if (isAttacking == true) return;
        HandleMovement();
        UpdateAnimationState();
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

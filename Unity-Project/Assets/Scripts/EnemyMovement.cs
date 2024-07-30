using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float _speed;

    private Rigidbody2D _rigidbody;
    private PlayerAwareness _playerAwarenessController;
    private Vector2 _targetDirection;
    private Animator _animator;

    private float atkTimer = 0f;
    [SerializeField]
    public float atkDuration = 1f;
    [SerializeField]
    public float distanceToAttack = 2f;
    private bool isAttacking = false;

    private Animator _animatorAttack;
    private Animator _animatorLife;
    public int hp = 100;
    private GameObject player;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwareness>();
        _animator = GetComponent<Animator>();
        _animatorAttack = gameObject.transform.GetChild(0).GetComponent<Animator>();
        _animatorLife = gameObject.transform.GetChild(1).GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (player.GetComponent<MovePlayer>().hp == 0) return;
        CheckTimer();
        if (isAttacking == true) return;
        UpdateTargetDirection();
        StartCoroutine(RotateTowardsTarget());
        HandleAttack();
    }

    private void UpdateTargetDirection()
    {
        if (_playerAwarenessController.awareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.directionToPlayer;
        } else
        {
            _targetDirection = Vector2.zero;
        }
    }

    private IEnumerator RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rigidbody.velocity = Vector2.zero;
            _animator.SetFloat("MoveX", 0);
            _animator.SetFloat("MoveY", 0);
            _animator.SetTrigger("Stop");
            yield return null;
        }

        float x = _targetDirection.x;
        float y = _targetDirection.y;
        _animator.SetFloat("MoveX", Math.Abs(x) < Math.Abs(y) ? 0 : x);
        _animator.SetFloat("MoveY", Math.Abs(y) < Math.Abs(x) ? 0 : y);

        _rigidbody.velocity = new Vector2(_targetDirection.x * _speed, _targetDirection.y * _speed);
        if (_animator.GetFloat("MoveY") < 0)
        {
            _animator.SetTrigger("Down");

        }
        yield return new WaitForSeconds(2f);

    }

    public void HandleAttack()
    {
        if (isAttacking == false && (_playerAwarenessController._player.position - _playerAwarenessController.transform.position).magnitude < distanceToAttack)
        {
            isAttacking = true;
            if (_animator.GetFloat("MoveX") == 0 && _animator.GetFloat("MoveY") == 0)
            {
                _animator.SetTrigger("TriggerAttackDown");
                _animatorAttack.SetTrigger("TriggerAttackDown");

            }
            else if (_animator.GetFloat("MoveX") > 0)
            {
                _animator.SetTrigger("TriggerAttackRight");
                _animatorAttack.SetTrigger("TriggerAttackRight");

            }
            else if (_animator.GetFloat("MoveX") < 0)
            {
                _animator.SetTrigger("TriggerAttackLeft");
                _animatorAttack.SetTrigger("TriggerAttackLeft");

            }
            else if (_animator.GetFloat("MoveY") > 0)
            {
                _animator.SetTrigger("TriggerAttackUp");
                _animatorAttack.SetTrigger("TriggerAttackUp");

            }
            else if (_animator.GetFloat("MoveY") < 0)
            {
                _animator.SetTrigger("TriggerAttackDown");
                _animatorAttack.SetTrigger("TriggerAttackDown");

            }
            _animator.SetFloat("MoveX", 0);
            _animator.SetFloat("MoveY", 0);
            _rigidbody.velocity = Vector2.zero;

        }

    }
    private void CheckTimer()
    {
        if (isAttacking == true)
        {
            atkTimer += Time.deltaTime;
            if (atkTimer >= atkDuration)
            {
                atkTimer = 0;
                isAttacking = false;
            }
        }
    }

    public void ReceiveDamage()
    {
        Debug.Log("damage taken");
        switch (hp)
        {
            case 100:
                hp = 66;
                _animatorLife.SetInteger("Hp", 66);
                break;
            case 66:
                hp = 33;
                _animatorLife.SetInteger("Hp", 33);
                break;
            case 33:
                hp = 0;
                _animatorLife.SetInteger("Hp", 0);
                Debug.Log("Morri");
                break;
        }
        Debug.Log(hp);
    }

}

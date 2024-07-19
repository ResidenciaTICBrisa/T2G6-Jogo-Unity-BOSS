using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rigidbody;
    private PlayerAwareness _playerAwarenessController;
    private Vector2 _targetDirection;
    private Animator _animator;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwareness>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        StartCoroutine(RotateTowardsTarget());
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

}

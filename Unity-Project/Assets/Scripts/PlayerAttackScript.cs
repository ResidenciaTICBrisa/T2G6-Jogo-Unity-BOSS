using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{

    private float atkTimer = 0f;
    public float atkDuration = 1f;
    private bool isAttacking = false;
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
    private void FixedUpdate()
    {
        CheckTimer();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(transform.parent.tag);
        if (isAttacking) return;
        if (other.CompareTag("Enemy") && transform.parent.tag == "Player")
        {
            if(other.name == "RobotT2")
            {
                other.GetComponent<RedMovement>().ReceiveDamage();
            } else
            {
                other.GetComponent<EnemyMovement>().ReceiveDamage();
                Debug.Log("Ataquei o Robo");
            }
        } else if (other.CompareTag("Player") && transform.parent.tag == "Enemy")
        {
            other.GetComponent<MovePlayer>().ReceiveDamage();
            Debug.Log("Ataquei o Player");
        }
        isAttacking = true;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Vector3 direction = (other.transform.position - transform.parent.transform.position).normalized;
            other.transform.GetComponent<Rigidbody2D>().AddForce(direction * 10000000, ForceMode2D.Force);
            Debug.Log(other.transform.GetComponent<Rigidbody2D>().velocity);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Player"))
        other.transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle, walk, attack, stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public IntegerValue maxHealth;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    private void Awake()
    {
        health = maxHealth.value;
    }

    void TakeDamage(int dam)
    {
        health -= dam;
        if(health<=0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D rb, float knockTime,int damage)
    {
        StartCoroutine(KnockCo(rb, knockTime));
        TakeDamage(damage);
    }

    IEnumerator KnockCo(Rigidbody2D myRigidBody, float knockTime)
    {
        if (myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidBody.velocity = Vector2.zero;

        }
    }
}

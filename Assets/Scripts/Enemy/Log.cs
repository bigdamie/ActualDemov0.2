using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    Rigidbody2D myrb;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        myrb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = EnemyState.idle;
    }

    private void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                ChangeAnim(temp - transform.position);

                myrb.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }
    }

    void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    void ChangeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if(direction.x <0)
            {
                SetAnimFloat(Vector2.left);

            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {

            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);

            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);

            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
            currentState = newState;
    }
}

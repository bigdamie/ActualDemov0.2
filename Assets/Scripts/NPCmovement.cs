using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmovement : Movement
{
    private Vector3 directionVector;
    private Transform myTransform;

    private Animator anim;
    public Collider2D bounds;
    private bool isMoving;
    public float minMoveTime;
    public float maxMoveTime;
    private float moveTimeSeconds;
    public float minWaitTime;
    public float maxWaitTime;
    private float waitTimeSeconds;

    // Start is called before the first frame update
    void Start()
    {
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        waitTimeSeconds = 0;
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    // Update is called once per frame
    public  void Update()
    {
        if (isMoving)
        {

            moveTimeSeconds -= Time.deltaTime;
            if (moveTimeSeconds <= 0)
            {
                moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
                isMoving = false;
            }
            else
                Move();
        }
        else
        {
            waitTimeSeconds -= Time.deltaTime;
            if (waitTimeSeconds <= 0)
            {
                ChooseDifferentDirection();
                isMoving = true;
                waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
            }
        }
    }

    private void ChooseDifferentDirection()
    {
        Vector3 temp = -directionVector;
       
        ChangeDirection();

        int loops = 0;
        if (temp == directionVector && loops < 10)
        {
            loops++;
            ChangeDirection();
        }
        
    }

    private void Move()
    {


        if (bounds.bounds.Contains(directionVector.normalized))
        {
            Debug.Log("bert");
            Motion(directionVector);
        }
        else
        {
            ChangeDirection();
        }
        UpdateAnimation();

    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                // Walking to the right
                directionVector = Vector3.right;
                break;
            case 1:
                // Walking up
                directionVector = Vector3.up;
                break;
            case 2:
                // Walking Left
                directionVector = Vector3.left;
                break;
            case 3:
                // Walking down
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
    }

    void UpdateAnimation()
    {
        anim.SetFloat("moveX", directionVector.x);
        anim.SetFloat("moveY", directionVector.y);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Motion(-directionVector);
    }

   

   

}

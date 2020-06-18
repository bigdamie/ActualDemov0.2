using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public Rigidbody2D myRigidbody;

    public virtual void Motion(Vector2 direction)
    {
        
        direction = direction.normalized;
        myRigidbody.velocity = direction * speed;
    }
}

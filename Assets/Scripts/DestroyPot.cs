using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPot : MonoBehaviour
{
    [SerializeField] Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : EnemyHealth
{
    [SerializeField] private Animator anim;
    [SerializeField] private float destroyDelay;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

  

    public override void Die()
    {        
        StartCoroutine(IDOTSkill());
       
    }

    IEnumerator IDOTSkill()
    {
        
        anim.SetTrigger("destroy");

        yield return new WaitForSeconds(destroyDelay);

        base.Die();

        Destroy(this.transform.parent.gameObject);
    }
}

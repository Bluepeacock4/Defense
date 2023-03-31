using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected float moveSpeed;

    protected override void Update()
    {
        base.Update();
        Move();
    }

    public virtual void Move()
    {
        if (attackRange.Attackable == false)
        {
            animator.SetBool("Move", true);
            transform.Translate(Vector3.left * moveSpeed * Time.smoothDeltaTime);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }
}

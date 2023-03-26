using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashmonsterAttack : EnemyWeapon
{
    private Animator animator;

    protected void Start()
    {
        Damage = 25;
        animator = GetComponent<Animator>();
    }

    protected override void Attack(IHitable target)
    {
        base.Attack(target);
    }
}

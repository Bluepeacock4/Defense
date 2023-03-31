using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : Weapon
{
    private Animator animator;

    public float MoveSpeed { get; private set; }

    protected void Start()
    {
        MoveSpeed = 2.5f;
        animator = GetComponent<Animator>();
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.smoothDeltaTime);
            yield return null;
        }
    }

    protected override void Attack(Character target)
    {
        base.Attack(target);
        animator.SetTrigger("Attack");
    }
}

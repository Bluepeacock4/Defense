using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : AllyWeapon
{
    private Animator animator;

    public float MoveSpeed { get; private set; }

    private void Start()
    {
        Damage = 25;
        animator = GetComponent<Animator>();
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        transform.Translate(Vector3.right * MoveSpeed * Time.smoothDeltaTime);
        yield return null;
    }

    protected override void Attack(IHitable target)
    {
        base.Attack(target);
        animator.SetTrigger("attack");
    }

    private void OnAttackAnimation()
    {
        Destroy(gameObject);
    }
}

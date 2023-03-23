using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour, IAttackable, IHitable
{
    private Animator animator;

    [SerializeField]
    private AllyAttackRange attackRange;
    [SerializeField]
    private GameObject attackObject;
    [SerializeField]
    private Transform attackPosition;
    private float attackCooldown;

    public virtual float AttackSpeed { get; protected set; }
    public virtual float Health {
        get
        {
            return Health;
        }

        protected set
        {
            Health = Mathf.Clamp(Health += value, 0, MaxHealth);
            if (Health <= 0)
            {
                Die();
            }
        }
    }
    public virtual float MaxHealth { get; protected set; }


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        attackCooldown = Mathf.Max(attackCooldown - Time.smoothDeltaTime, 0);

        if (attackRange.Attackable && attackCooldown == 0)
        {
            Attack();
            attackCooldown = 1.0f / AttackSpeed;
        }
    }
    
    public virtual void Attack()
    {
        animator.SetTrigger("attack");
    }

    public virtual void Hit(float damage)
    {
        animator.SetTrigger("hit");
        Health = damage;
    }

    protected virtual void Die()
    {
        animator.SetTrigger("die");
    }

    public virtual void OnAttackAnimation()
    {
        Instantiate(attackObject, attackPosition.position, Quaternion.identity);
    }

    public virtual void OnDieAnimation()
    {
        Destroy(gameObject);
    }
}

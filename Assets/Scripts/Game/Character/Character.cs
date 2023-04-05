using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    protected Animator animator;

    [SerializeField] protected AttackRange attackRange;
    [SerializeField] protected GameObject attackObject;
    [SerializeField] protected Transform attackPosition;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float maxHealth;
    protected float attackCooldown = 0;

    protected float health;
    public virtual float Health
    {
        get { return health; }
        protected set { health = Mathf.Clamp(value, 0, maxHealth); }
    }

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        float prev_attackCooldown = attackCooldown;
        attackCooldown = Mathf.Max(attackCooldown - Time.smoothDeltaTime, 0);

        if (prev_attackCooldown > 0 && attackCooldown == 0)
        {
            Attack();
        }
        
    }

    public virtual void Attack()
    {
        if (attackCooldown == 0 && attackRange.Attackable)
        {
            animator.SetTrigger("Attack");
            attackCooldown = 2.0f / attackSpeed;
        }
    }

    public virtual void StopAttack()
    {
        animator.SetTrigger("StopAttack");
    }

    public virtual void Hit(float damage)
    {
        animator.SetTrigger("Hit");
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        attackRange.gameObject.SetActive(false);
        animator.SetTrigger("Die");

        if(gameObject.tag == "Enemy")
        {
            GameManager.Instance.killCount++;
        }

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

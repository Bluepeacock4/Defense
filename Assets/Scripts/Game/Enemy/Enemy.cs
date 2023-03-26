using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IMovable, IAttackable, IHitable
{
    private Animator animator;

    [SerializeField]
    private EnemyAttackRange attackRange;
    [SerializeField]
    private GameObject attackObject;
    [SerializeField]
    private Transform attackPosition;
    private float attackCooldown;


    public virtual float MoveSpeed { get; protected set; }
    public virtual float AttackSpeed { get; protected set; }

    protected float health;
    public virtual float Health
    {
        get
        {
            return health;
        }

        protected set
        {
            health = Mathf.Clamp(health + value, 0, MaxHealth);
            if (health <= 0)
            {
                Die();
            }
        }
    }
    public virtual float MaxHealth { get; protected set; }

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        Move();

        attackCooldown = Mathf.Max(attackCooldown - Time.smoothDeltaTime, 0);

        if (attackRange.Attackable && attackCooldown == 0)
        {
            Attack();
            attackCooldown = 1.0f / AttackSpeed;
        }
    }

    public virtual void Move()
    {
        if (attackRange.Attackable == false)
        {
            animator.SetBool("Move", true);
            transform.Translate(Vector3.left * MoveSpeed * Time.smoothDeltaTime);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    public virtual void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public virtual void Hit(float damage)
    {
        // animator.SetTrigger("Hit");
        Health -= damage;
    }

    protected virtual void Die()
    {
        animator.SetTrigger("Die");
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

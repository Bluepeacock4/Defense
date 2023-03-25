using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyWeapon : MonoBehaviour
{
    public float Damage { get; protected set; }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Attack(gameObject.GetComponent<IHitable>());
        }
    }

    protected virtual void Attack(IHitable target)
    {
        target.Hit(Damage);
    }
}

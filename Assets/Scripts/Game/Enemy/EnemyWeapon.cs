using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float Damage { get; protected set; }


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ally")
        {
            Attack(collision.gameObject.GetComponent<IHitable>());
        }
    }

    protected virtual void Attack(IHitable target)
    {
        target.Hit(Damage);
    }

    protected virtual void DestroyWeapon()
    {
        Destroy(gameObject);
    }
}

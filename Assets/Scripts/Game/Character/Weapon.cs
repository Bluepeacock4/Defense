using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private float damage;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            Attack(collision.gameObject.GetComponent<Character>());
        }
    }

    protected virtual void Attack(Character target)
    {
        target.Hit(damage);
    }

    protected virtual void DestroyWeapon()
    {
        Destroy(gameObject);
    }
}

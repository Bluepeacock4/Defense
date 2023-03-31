using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    [SerializeField] private UnityEvent onBeingAttackable;
    [SerializeField] private UnityEvent onBeingNotAttackable;
    [SerializeField] private string targetTag;
    private int targetCount = 0;

    private bool attackable;
    public bool Attackable
    {
        get { return attackable; }
        private set
        {
            bool prev_attackable = attackable;
            attackable = value;

            if (prev_attackable != attackable)
            {
                if (attackable)
                {
                    onBeingAttackable.Invoke();
                }
                else onBeingNotAttackable.Invoke();
            }
        }
    }
    
    private void Update()
    {
        if (targetCount > 0)
            Attackable = true;
        else
            Attackable = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            targetCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            targetCount--;
        }
    }

}

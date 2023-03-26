using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashmonster : Enemy
{
    protected override void Start()
    {
        base.Start();
        MoveSpeed = 1;
        AttackSpeed = 1;
        MaxHealth = 100;
        Health = MaxHealth;
    }
}

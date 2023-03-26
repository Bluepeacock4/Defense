using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : Ally
{
    protected override void Start()
    {
        base.Start();
        AttackSpeed = 0.5f;
        MaxHealth = 100;
        Health = MaxHealth;
    }
}

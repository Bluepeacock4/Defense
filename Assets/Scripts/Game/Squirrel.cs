using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : Ally
{
    private void Start()
    {
        AttackSpeed = 0.5f;
        MaxHealth = 100;
        Health = MaxHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Ally
{
    protected override void Start()
    {
        base.Start();
        Health = maxHealth;
    }
}

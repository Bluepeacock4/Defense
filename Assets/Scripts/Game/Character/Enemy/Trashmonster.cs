using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashmonster : Enemy
{
    protected override void Start()
    {
        base.Start();
        Health = maxHealth;
    }
}

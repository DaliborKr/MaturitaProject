﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileEnemy1 : FireProjetileEnemy
{
    public override void SetProjectileDirectory()
    {
        base.SetProjectileDirectory();

        
        fireDirection = ((pcPos - startPos).normalized);

        if (fireDirection.x > 0)
        {
            fireDirection.x *= -1;
        }
        fireDirection.y += 0.3f;
    }
}

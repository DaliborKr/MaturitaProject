using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileEnemy2 : FireProjetileEnemy
{
    public override void SetProjectileDirectory()
    {
        base.SetProjectileDirectory();

        fireDirection = startPos.normalized;
        fireDirection.x = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileEnemy2 : FireProjetileEnemy
{
    public override void SetProjectileDirectory()
    {
        base.SetProjectileDirectory();      

        if (pcPos.x < startPos.x)
        {
            fireDirection = new Vector2(0.4f, 1);
        }
        else
        {
            fireDirection = new Vector2(-0.4f, 1);
        }
    }
}

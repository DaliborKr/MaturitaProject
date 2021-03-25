using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileEnemy3 : FireProjetileEnemy
{
    public override void SetProjectileDirectory()
    {
        base.SetProjectileDirectory();

        
        fireDirection = ((pcPos - startPos).normalized);

        if (fireDirection.x < 0)
        {
            fireDirection.x *= -1;
        }
        fireDirection.y += 0.3f;
        

        //fireDirection = new Vector2(0.8f, 0.3f);
    }
}

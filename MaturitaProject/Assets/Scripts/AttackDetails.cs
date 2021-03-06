using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetails
{
    public int damageNumber
    {
        get;
        private set;
    }

    public Vector2 position
    {
        get;
        private set;
    }

    public int facingDir
    {
        get;
        private set;
    }

    public AttackDetails(int damageNumber, Vector2 position, int facinfDir)
    {
        this.damageNumber = damageNumber;
        this.position = position;
        this.facingDir = facinfDir;
    }
}

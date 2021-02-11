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

    public int facingDir
    {
        get;
        private set;
    }

    public AttackDetails(int damageNumber, int facingDir)
    {
        this.damageNumber = damageNumber;
        this.facingDir = facingDir;
    }
}

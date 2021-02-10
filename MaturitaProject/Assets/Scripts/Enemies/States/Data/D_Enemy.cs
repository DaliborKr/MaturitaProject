using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class D_Enemy : ScriptableObject
{
    public float wallCheckDist = 0.25f;
    public float ledgeCheckDist = 0.35f;

    public LayerMask whatIsGround;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class D_Enemy : ScriptableObject
{
    public float wallCheckDist = 0.25f;
    public float ledgeCheckDist = 0.35f;

    public Vector2 minAgroRangeDist = new Vector2(2, 2);
    public Vector2 maxAgroRangeDist = new Vector2(5, 2);

    public float meleeAttackRange = 1f;

    public int maxHealth = 100;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class D_Enemy : ScriptableObject
{
    public float wallCheckDist = 0.25f;
    public float ledgeCheckDist = 0.35f;

    public float minAgroRangeDist = 2f;
    public Vector2 maxAgroRangeDist = new Vector2(5,2);

    public int maxHealth = 100;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
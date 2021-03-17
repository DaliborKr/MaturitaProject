using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int score;

    public int maxNumberOfJumps;

    public int maxHealth;
    public int currentHealth;

    public bool fireAvaiableD;
    public int projectileTypeD;
    public int damgeMeleeAttack;

    public bool canDash;
    public bool canWallJump;

    public float[] position;

    public PlayerData(PlayerController playerController, PlayerCombatController playerCombatController, PlayerGetDamage playerGetDamage, ScoreText scoreText)
    {
        this.score = scoreText.score;

        this.maxNumberOfJumps = playerController.maxNumberOfJumps;

        this.maxHealth = playerGetDamage.maxHealth;
        this.currentHealth = playerGetDamage.currentHealth;

        this.fireAvaiableD = playerCombatController.fireAvaiable;
        this.projectileTypeD = playerCombatController.projectileType;
        this.damgeMeleeAttack = playerCombatController.damageNumberAttack1;

        this.canDash = playerController.dashAvaiable;
        this.canWallJump = playerController.wallJumpAvaiable;

        this.position = new float[3];
        this.position[0] = playerController.currentSpawnPos.x;
        this.position[1] = playerController.currentSpawnPos.y;
        this.position[2] = playerController.currentSpawnPos.z;
    }


}

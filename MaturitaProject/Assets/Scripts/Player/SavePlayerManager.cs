using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerManager : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerCombatController playerCombatController;
    public PlayerGetDamage playerGetDamage;
    public ScoreText scoreText;
    public Transform spawnLevelPos;

    private void Awake()
    {
        
        LoadPlayer();
        playerController.currentSpawnPos = spawnLevelPos.position;
        SavePlayer();
        LoadPlayer();
        
    }

    public void SavePlayer() 
    {
        SaveManager.SavePlayerData(playerController, playerCombatController, playerGetDamage, scoreText);
    }

    public void LoadPlayer()
    {
        PlayerData playerData = SaveManager.LoadPlayerData();

        scoreText.score = playerData.score;

        playerController.maxNumberOfJumps = playerData.maxNumberOfJumps;

        playerGetDamage.maxHealth = playerData.maxHealth;
        playerGetDamage.currentHealth = playerData.currentHealth;

        playerCombatController.fireAvaiable = playerData.fireAvaiableD;
        playerCombatController.projectileType = playerData.projectileTypeD;
        playerCombatController.damageNumberAttack1 = playerData.damgeMeleeAttack;

        playerController.dashAvaiable = playerData.canDash;
        playerController.wallJumpAvaiable = playerData.canWallJump;

        
        Vector3 position;
        position.x = playerData.position[0];
        position.y = playerData.position[1];
        position.z = playerData.position[2];
        transform.position = position;
        
    }

}

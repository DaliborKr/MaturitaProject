using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    public void SavePlayer() 
    {
        SaveManager.SavePlayerData(playerController, playerCombatController, playerGetDamage, scoreText);
        CoinsCollectedNotSaved.SetCollectedCoinsAfterSave();
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

        CoinsCollectedNotSaved.ClearCollectedCoins();

    }

    public void LoadPlayerAndLevel()
    {
        PlayerData playerData = SaveManager.LoadPlayerData();
        SceneManager.LoadScene(playerData.currentLevel);  
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{

    public static void SavePlayerData(PlayerController playerController, PlayerCombatController playerCombatController, PlayerGetDamage playerGetDamage, ScoreText scoreText)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/playerData.dal";
        Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData playerData = new PlayerData(playerController, playerCombatController, playerGetDamage, scoreText);

        formatter.Serialize(stream, playerData);

        stream.Close();
    }

    public static PlayerData LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/playerData.dal";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData playerData = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return playerData;
        }

        Debug.LogError($"File not found! (Path: {path})");
        return null;
    }

}

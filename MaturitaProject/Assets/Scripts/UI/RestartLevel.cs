using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    
    public void RestartCurrentLevel()
    {
        Debug.Log("ynovu na49st scenu"); 
        Time.timeScale = (1f);
        Time.fixedDeltaTime = Time.timeScale * 0.01f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

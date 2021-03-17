using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public Vector3 nextLevelSpawn;

    public Vector2 portalArea;

    private bool isPlayerInArea;

    public LayerMask whatIsPlayer;

    public string sceneName;

    private SavePlayerManager savePlayerManager;


    // Start is called before the first frame update
    void Start()
    {
        savePlayerManager = GameObject.Find("Player").GetComponent<SavePlayerManager>();
    }

    private void Update()
    {
        ChangeLevel();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckPlayerInArea();
    }

    public void CheckPlayerInArea()
    {
        isPlayerInArea = Physics2D.OverlapBox(transform.position, portalArea, 0, whatIsPlayer);
    }

    public void ChangeLevel()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInArea)
        {
            //player.transform.position = nextLevelSpawn;
            savePlayerManager.SavePlayer();
            LoadScene();
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnDrawGizmos()
    {
        Vector3 vecotorHelpMax = new Vector3(portalArea.x, portalArea.y, 1.0f);
        Gizmos.DrawWireCube(transform.position, vecotorHelpMax);
    }
}

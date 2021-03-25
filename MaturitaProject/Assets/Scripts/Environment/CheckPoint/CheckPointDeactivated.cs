using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointDeactivated : MonoBehaviour
{
    public Vector2 checkPointArea;

    private bool isPlayerInArea;

    public LayerMask whatIsPlayer;

    private SavePlayerManager savePlayerManager;

    public PlayerController pc;

    public CheckPointActiveManager checkPointActiveManager;


    // Start is called before the first frame update
    void Start()
    {
        savePlayerManager = GameObject.Find("Player").GetComponent<SavePlayerManager>();
    }

    private void Update()
    {
        SaveLevel();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckPlayerInArea();
    }

    public void CheckPlayerInArea()
    {
        isPlayerInArea = Physics2D.OverlapBox(transform.position, checkPointArea, 0, whatIsPlayer);
    }

    public void SaveLevel()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInArea)
        {
            pc.currentSpawnPos = transform.position;
            savePlayerManager.SavePlayer();
            checkPointActiveManager.SetActiveCheckPoint(true);
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 vecotorHelpMax = new Vector3(checkPointArea.x, checkPointArea.y, 1.0f);
        Gizmos.DrawWireCube(transform.position, vecotorHelpMax);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lever : MonoBehaviour
{
    private Animator animator;

    public bool isActivated;

    public Vector2 leverArea;

    private bool isPlayerInArea;
    private bool canBeSaved;

    public LayerMask whatIsPlayer;

    private string key;

    private void Awake()
    {
        LevelManager.OnTeleported += DeactivateAfterTeleport;
        CheckPointDeactivated.OnCheckPointed += SaveActive;

        animator = GetComponent<Animator>();

        key = SceneManager.GetActiveScene().name + gameObject.name;
        if (PlayerPrefs.GetInt(key) == 0)
        {
            isActivated = false;
            animator.SetBool("isActivated", isActivated);
        }
        else
        {
            isActivated = true;
            animator.SetBool("isActivated", isActivated);
        }
    }

    void Start()
    {
        canBeSaved = false;
    }
    
    void Update()
    {
        ActivateLever();
    }

    private void FixedUpdate()
    {
        CheckPlayerInArea();
    }

    public void CheckPlayerInArea()
    {
        isPlayerInArea = Physics2D.OverlapBox(transform.position, leverArea, 0, whatIsPlayer);
    }

    public void ActivateLever()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInArea && !isActivated)
        {
            isActivated = true;
            canBeSaved = true;           
            animator.SetBool("isActivated", isActivated);
        }
        else if (Input.GetKeyDown(KeyCode.E) && isPlayerInArea && isActivated)
        {
            isActivated = false;
            canBeSaved = false;
            PlayerPrefs.SetInt(key, 0);
            animator.SetBool("isActivated", isActivated);
        }
    }

    public void SaveActive()
    {
        if (canBeSaved)
        {
            PlayerPrefs.SetInt(key, 1);
        }     
    }

    public void DeactivateAfterTeleport()
    {
        isActivated = false;
        PlayerPrefs.SetInt(key, 0);
    }
    private void OnDestroy()
    {
        LevelManager.OnTeleported -= DeactivateAfterTeleport;
        CheckPointDeactivated.OnCheckPointed -= SaveActive;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, leverArea);
    }

}

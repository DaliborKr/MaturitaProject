﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLinePlayer : MonoBehaviour
{
    private LineRenderer fireLine;

    private PlayerController pc;

    private GameObject firePointPlayer;

    private Vector2 fireDirection;

    private Vector2 fireDirectionMultiplied;

    private Vector3 fireDirectionHelpV3;

    private int facingAdder;

    void Start()
    {
        fireLine = GetComponent<LineRenderer>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        firePointPlayer = GameObject.Find("firePointPlayer");
    }

    void FixedUpdate()
    {
        SetFireLine();
    }

    private void SetFireLine()
    {
        int facingDir = pc.GetFacingDir();

        if(facingDir == 1)
        {
            facingAdder = 5;
        }
        else
        {
            facingAdder = -5;
        }

        Vector3 mousePositionV3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 mousePositionV2 = new Vector2(firePointPlayer.transform.position.x + facingAdder, mousePositionV3.y);
        Vector2 lineFirePointPlayerV2 = new Vector2(firePointPlayer.transform.position.x, firePointPlayer.transform.position.y);


        mousePositionV3.z = 0;

        fireDirection = ((mousePositionV2 - lineFirePointPlayerV2).normalized);

        fireDirectionMultiplied = fireDirection * 4;

        float angle = Vector3.Angle(transform.right, fireDirectionMultiplied);

        Vector3 lineFirePointPlayerV3 = new Vector3(lineFirePointPlayerV2.x, lineFirePointPlayerV2.y, -1);

        if (angle < 75)
        {

            Vector3 fireDirectionV3 = new Vector3(fireDirectionMultiplied.x, fireDirectionMultiplied.y, 0);

            fireDirectionHelpV3 = fireDirectionV3;

            fireLine.SetPosition(0, lineFirePointPlayerV3);
            fireLine.SetPosition(1, (fireDirectionV3 + lineFirePointPlayerV3));
        }
        else
        {
            fireLine.SetPosition(0, lineFirePointPlayerV3);
            fireLine.SetPosition(1, (fireDirectionHelpV3 + lineFirePointPlayerV3));
        }
        
    }

    public Vector2 getFireDirection()
    {
        return fireDirection;
    }
}

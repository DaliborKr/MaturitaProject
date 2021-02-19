using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLinePlayer : MonoBehaviour
{
    private LineRenderer fireLine;

    private PlayerController pc;

    private GameObject firePointPlayer;

    private Vector2 fireDirection;

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
        Vector3 mousePositionV3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 mousePositionV2 = new Vector2(mousePositionV3.x, mousePositionV3.y);
        Vector2 lineFirePointPlayerV2 = new Vector2(firePointPlayer.transform.position.x, firePointPlayer.transform.position.y);

        mousePositionV3.z = 0;

        fireDirection = ((mousePositionV2 - lineFirePointPlayerV2).normalized) * 4;

        Vector3 lineFirePointPlayerV3 = new Vector3(lineFirePointPlayerV2.x, lineFirePointPlayerV2.y, -1);
        Vector3 fireDirectionV3 = new Vector3(fireDirection.x, fireDirection.y, 0);

        fireLine.SetPosition(0, lineFirePointPlayerV3);
        fireLine.SetPosition(1, (fireDirectionV3 + lineFirePointPlayerV3));
    }
}

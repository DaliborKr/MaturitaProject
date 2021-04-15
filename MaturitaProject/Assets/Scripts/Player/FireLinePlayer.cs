using System.Collections;
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

    private bool isFlipped;

    void Start()
    {
        fireLine = GetComponent<LineRenderer>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        firePointPlayer = GameObject.Find("firePointPlayer");
        isFlipped = false;
    }

    void Update()
    {
        SetFireLine();
    }

    private void SetFireLine()
    {
        int facingDir = pc.GetFacingDir();

        if(facingDir == 1)
        {
            facingAdder = 200;
        }
        else
        {
            facingAdder = -200;
        }
        // Tady je bod kde jsi byl

        Vector3 mousePositionV3 = Input.mousePosition;

        Vector2 mousePositionV2 = new Vector2(firePointPlayer.transform.position.x + facingAdder, mousePositionV3.y -500);
        Vector2 lineFirePointPlayerV2 = new Vector2(firePointPlayer.transform.position.x, firePointPlayer.transform.position.y);

        mousePositionV3.z = 0;

        fireDirection = ((mousePositionV2 - lineFirePointPlayerV2).normalized);

        fireDirectionMultiplied = fireDirection * 1.3f;

        float angle = Vector3.Angle(transform.right, fireDirectionMultiplied);

        Vector3 lineFirePointPlayerV3 = new Vector3(lineFirePointPlayerV2.x, lineFirePointPlayerV2.y, -1);

        if (angle < 45 || isFlipped)
        {
            Vector3 fireDirectionV3 = new Vector3(fireDirectionMultiplied.x, fireDirectionMultiplied.y, 0);

            fireDirectionHelpV3 = fireDirectionV3;

            fireLine.SetPosition(0, lineFirePointPlayerV3);
            fireLine.SetPosition(1, (fireDirectionV3 + lineFirePointPlayerV3));
            isFlipped = false;
        }
        else
        {
            fireLine.SetPosition(0, lineFirePointPlayerV3);
            fireLine.SetPosition(1, (fireDirectionHelpV3 + lineFirePointPlayerV3));
        }
        
    }

    public Vector2 getFireDirection()
    {
        return fireDirectionHelpV3;
    }

    public void FlipReaction()
    {
        isFlipped = true;
    }
}

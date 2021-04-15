using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damageNumber;

    public Transform hitBoxPoint;

    public Vector2 damageDistance;

    public LayerMask whatIsPlayer;

    void FixedUpdate()
    {
        CheckSpikeHitbox();
    }

    public void CheckSpikeHitbox()
    {
        Collider2D[] objects = Physics2D.OverlapBoxAll(hitBoxPoint.position, damageDistance, 0, whatIsPlayer);

        AttackDetails attackDetails = new AttackDetails(damageNumber, transform.position, 1);

        foreach (Collider2D collider in objects)
        {
            collider.transform.SendMessage("GetDamageSpikes", attackDetails);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(hitBoxPoint.transform.position, damageDistance);
    }
}

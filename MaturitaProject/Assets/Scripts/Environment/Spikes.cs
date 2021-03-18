using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damageNumber;

    public Transform hitBoxPoint;

    public Vector2 damageDistance;

    public LayerMask whatIsPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckProjectileHitbox();
    }

    public void CheckProjectileHitbox()
    {
        Collider2D[] objects = Physics2D.OverlapBoxAll(hitBoxPoint.position, damageDistance, 0, whatIsPlayer);

        AttackDetails attackDetails = new AttackDetails(damageNumber, transform.position, 1);

        foreach (Collider2D collider in objects)
        {
            Debug.Log("melo by byt au");
            collider.transform.SendMessage("GetDamageSpikes", attackDetails);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(hitBoxPoint.transform.position, damageDistance);
    }
}

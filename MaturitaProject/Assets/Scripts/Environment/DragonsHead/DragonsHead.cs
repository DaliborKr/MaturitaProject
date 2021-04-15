using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonsHead : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float startDelay;
    public float spawnInterval;

    void Start()
    {
        InvokeRepeating("SpawnProjectile", startDelay, spawnInterval);
    }

    public void SpawnProjectile()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}


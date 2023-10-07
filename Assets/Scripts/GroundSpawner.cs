using System;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    private ObjectPooler objectPooler;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        objectPooler.SpawnFromPool("Ground", currentPosition, Quaternion.identity);
    }
}
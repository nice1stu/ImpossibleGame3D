using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroundSpawner : MonoBehaviour
{
    private ObjectPooler objectPooler;
    private int heightAdjustment;
    private int frameCounter = 0;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void Update()
    {
        frameCounter++;

        if (frameCounter==300)
        {
            int random = Random.Range(-2, 2);
            Debug.Log(random);
            random = Mathf.Clamp(random, -1, 1);
            heightAdjustment = random;
            transform.position += new Vector3(0, heightAdjustment, 0);
            frameCounter = 0;
        }
        Vector3 currentPosition = transform.position;
        objectPooler.SpawnFromPool("Ground", currentPosition, Quaternion.identity);
    }
}
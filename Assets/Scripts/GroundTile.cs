using System.Collections;
using UnityEngine;

public class GroundTile : MonoBehaviour, IPooledObjects
{
    public float tileSpacing = 1.1f;

    private float timeSinceSpawn;

    public void OnObjectSpawn()
    {
        Debug.Log("Spawned");
        timeSinceSpawn = 0f;
    }

    public void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn > 0.3f)
        {
            ObjectPooler.Instance.DespawnToPool("Ground", gameObject);
        }

        transform.position += new Vector3(0, 0, tileSpacing);
    }
}
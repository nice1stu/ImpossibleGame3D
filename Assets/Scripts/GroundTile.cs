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

        if (timeSinceSpawn > 0.5f)
        {
            StartCoroutine(DestroyGameObject());
            //ObjectPooler.Instance.DespawnToPool("Ground", gameObject);
        }

        transform.position += new Vector3(0, 0, tileSpacing);
    }
    
    private IEnumerator DestroyGameObject()
    {
        yield return null;
        Destroy(gameObject);
    }
}
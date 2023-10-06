using System.Collections;
using UnityEngine;

public class GroundTile : MonoBehaviour, IPooledObjects
{
    public float tileSpacing = 1f;

    public void OnObjectSpawn()
    {
        Debug.Log("Spawned");
        StartCoroutine(DespawnAfterDelay());
    }

    private IEnumerator DespawnAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        ObjectPooler.Instance.DespawnToPool("Ground", gameObject);
    }

    public void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, tileSpacing);
    }
}
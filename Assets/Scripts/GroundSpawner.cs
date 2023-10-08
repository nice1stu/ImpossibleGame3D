using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class GroundSpawnerInst : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private float Interval => 1f/platformMoveSpeed;
    [SerializeField] private float platformMoveSpeed = 4f;
    
    private IObjectPool<GameObject> pool;
    private GameObject platformPool;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private int startingPlatformCount = 50;

    [SerializeField] private GameObject[] hazards;
    [SerializeField, Range(0f, 1f)] private float hazardChance = 0.1f;

    private void Awake()
    {
        platformPool = new GameObject("Platform Pool");
        
        pool = new ObjectPool<GameObject>(
            () => Instantiate(prefab, platformPool.transform),
            OnGet,
            x => x.SetActive(false),
            Destroy,
            false);
    }

    private void OnGet(GameObject obj)
    {
        obj.SetActive(true);
        StartCoroutine(ReturntoPool(obj));
    }

    private IEnumerator Start()
    {
        StartingPlatform();
        
        while(true)
        {
            var randomAmount = Random.Range(3, 8);
            yield return SpawnPlatformSegment(randomAmount);
            var randomHeight = Random.Range(-1, 2);
            transform.position = new Vector3(
                transform.position.x, 
                transform.position.y + randomHeight,
                transform.position.z);
        }
    }

    private GameObject SpawnHazard()
    {
        var random = Random.Range(0, hazards.Length);
        var instance = Instantiate(hazards[random], transform.position, Quaternion.identity);
        Destroy(instance, lifetime);
        return instance;
    }

    private IEnumerator SpawnPlatformSegment(int amount)
    {
        int count = 0;
        for (int i = 0; i < amount; i++)
        {
            var canSpawnHazard = count < 3;
            var random = Random.Range(0f, 1f);
            GameObject instance;
            if (random < hazardChance && canSpawnHazard)
            {
                instance = SpawnHazard();
                count++;
            }
            else
            {
                instance = pool.Get();
                count = 0;
            }

            if (instance.TryGetComponent<GroundTile>(out var groundTile))
                groundTile.moveSpeed = platformMoveSpeed;

            instance.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Interval);
        }
    }

    private IEnumerator ReturntoPool(GameObject instance)
    {
        yield return new WaitForSeconds(lifetime);
        pool.Release(instance);
    }

    private void StartingPlatform()
    {
        for (int i = 0; i < startingPlatformCount; i++)
        {
            var instance = pool.Get();
            instance.transform.SetParent(platformPool.transform);
            instance.transform.SetPositionAndRotation(new Vector3(transform.position.x, 0f, i), Quaternion.identity);
            if (instance.TryGetComponent<GroundTile>(out var groundTile))
                groundTile.moveSpeed = platformMoveSpeed;
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
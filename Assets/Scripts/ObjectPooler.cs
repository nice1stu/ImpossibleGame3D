using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int maxPoolSize;
    }

    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.maxPoolSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Pool with tag " + tag + " doesn't exist");
            return null;
        }
        GameObject object2Spawn = poolDictionary[tag].Dequeue();
        object2Spawn.SetActive(true);
        object2Spawn.transform.position = position;
        object2Spawn.transform.rotation = rotation;

        IPooledObjects pooledObj = object2Spawn.GetComponent<IPooledObjects>();
        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }
        poolDictionary[tag].Enqueue(object2Spawn);
        return object2Spawn;
    }
    
    public void DespawnToPool(string tag, GameObject objToDespawn)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogError("Pool with tag " + tag + " doesn't exist");
            return;
        }
        objToDespawn.SetActive(false);
        Debug.Log("Despawned");
        poolDictionary[tag].Enqueue(objToDespawn);
    }
}

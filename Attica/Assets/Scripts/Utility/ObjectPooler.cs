using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int numberOfObjects;
    }


    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> pooldictionary;

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        pooldictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.numberOfObjects; i++)
            {

                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            pooldictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!pooldictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with Tag " + " doesn't exist");
            return null;
        }

        GameObject objectToSpawn = pooldictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        iPoolerObject poolerObj = objectToSpawn.GetComponent<iPoolerObject>();

        if (poolerObj != null)
        {
            poolerObj.OnSpawnedByPool();
        }

        pooldictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

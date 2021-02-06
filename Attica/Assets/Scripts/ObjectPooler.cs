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
        public int size;
    }


    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> pooldictionary;

    void Start()
    {
        pooldictionary = new Dictionary<string, Queue<GameObject>>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

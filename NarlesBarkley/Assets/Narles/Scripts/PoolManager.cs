using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PoolManager : MonoBehaviour
{
    // Member Class for a Prefab entered into the object pool
    [Serializable]
    public class ObjectPoolEntry
    {
        //the object to pre-instansiate
        [SerializeField]
        public GameObject prefab;
        // quantity of the object to pre-instantiate
        [SerializeField]
        public int count = 3;
    }

    //The object prefabs which the pool can handle
    public ObjectPoolEntry[] entries;
    // The pooled objects currently available.  Indexed by the index of the objectPrefabs
    [HideInInspector]
    public List<GameObject>[] pool;
    // container to store unused items in
    protected GameObject containerObject;
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public List<GameObject> pool;
    public int poolSize;
    public GameObject poolPrefab;

    public Pool(GameObject prefab, int size)
    {
        poolPrefab = prefab;
        poolSize = size;
    }   

    void Start()
    {
        InitializePool();
    }

    void Update()
    {

    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(poolPrefab);
            SetUpObject(obj);
        }
    }

    private void SetUpObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.parent = this.transform;
        pool.Add(obj);
    }

    public GameObject GetObject()
    {
        for(int i = 0; i < poolSize; i++)
        {
            if (!pool[i].activeSelf)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        GameObject obj = Instantiate(poolPrefab);
        SetUpObject(obj);
        obj.SetActive(true);
        return obj;
    }
}

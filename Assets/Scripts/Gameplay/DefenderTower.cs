using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderTower : Tower
{
    public Pool defendersPool;
    public Transform spawnPoint;
    void Start()
    {
        SpawnDefenders(3);
    }

    void Update()
    {
        
    }

    public void SpawnDefenders(int cuantity)
    {
        Vector3 pos = spawnPoint.position;
        for (int i = 0; i < cuantity; i++)
        {
            GameObject defender = defendersPool.GetObject();
            defender.transform.position = pos + new Vector3(1, 0, 0);
            pos = defender.transform.position;
        }

    }
}

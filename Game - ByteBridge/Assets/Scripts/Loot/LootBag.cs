using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    [SerializeField] public List<GameObject> lootList = new List<GameObject>();

    public void SpawnLoot(Transform enemyTransform)
    {
        int randomPercentage = UnityEngine.Random.Range(0, 100);
        foreach (var loot in lootList)
        {
            if (loot.GetComponent<Loot>().dropChance > randomPercentage) 
            {
                Instantiate(loot, enemyTransform);
                
            }
        }
    }
}

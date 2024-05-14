using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : MonoBehaviour
{
   [SerializeField] private GameObject enemyPrefab;
   [SerializeField] private GameObject xPrefab;

   [SerializeField] private float warningDuration = 3f;
   private float currentWarningTime = 0f;
   private GameObject warning;
   private bool spawned = false;
   private LootBag lootBag;
   private bool lootSpawned = false;
   private void Start()
   {
      warning = Instantiate(xPrefab, gameObject.transform);
      lootBag = GetComponent<LootBag>();
   }

   private void Update()
   {
      currentWarningTime += Time.fixedDeltaTime;
      if (spawned)
      {
         var enemy = gameObject.GetComponentInChildren<EnemyBrain>();
         if (enemy == null && lootSpawned == false)
         {
            lootBag.SpawnLoot(gameObject.transform);
            lootSpawned = true;
         }
         return;
      }
      if (currentWarningTime >= warningDuration && spawned == false)
      {
         Destroy(warning);
         Instantiate(enemyPrefab, gameObject.transform);
         spawned = true;
      }
   }
}

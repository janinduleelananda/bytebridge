using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Loot:MonoBehaviour
{
   public string lootName;
   public int dropChance;

   public Loot(string lootName, int dropChance)
   {
      this.lootName = lootName;
      this.dropChance = dropChance;
   }
   
   public void LootDo()
   {
      Debug.Log("Loot: " + lootName + " dropped with a " + dropChance + "% chance");
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      var player = other.gameObject.GetComponent<PlayerMovement>();
      if (player != null)
      {
         LootDo();
         Destroy(gameObject);
      }
   }
}

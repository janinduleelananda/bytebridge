using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
   [Header("Prefabs")] [SerializeField] private GameObject muzzle;
   [SerializeField] private Transform muzzlePosition;
   [SerializeField] private GameObject projectile;

   [Header("Config")] [SerializeField] private float fireDistance = 10;
   [SerializeField] private float fireRate = 0.5f;

   private Transform player;
   private Vector2 offset;

   private float timeSinceLastShot = 0f;
   private Transform closestEnemy;
   private Animator anim;

   private void Start()
   {
      anim = GetComponent<Animator>();
      timeSinceLastShot = fireRate;
      player = GameObject.Find("Player").transform;
      
   }

   private void Update()
   {
      transform.position = (Vector2)player.position + offset;
      FindClosestEnemy();
      AimAtEnemy();
      Shooting();
   }

   void AimAtEnemy()
   {
      if (closestEnemy != null)
      {
         Vector3 direction = closestEnemy.position - transform.position;
         direction.Normalize();

         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(0,0,angle);
         transform.position = (Vector2)player.position + offset;
      }
   }
   private void FindClosestEnemy()
   {
      closestEnemy = null;
      float closestDistance = Mathf.Infinity;
      EnemyBrain[] enemies = FindObjectsOfType<EnemyBrain>();
      foreach (EnemyBrain enemy in enemies)
      {
         float distance = Vector2.Distance(transform.position, enemy.transform.position);
         if (closestDistance > distance && distance <= fireDistance)
         {
            closestEnemy = enemy.transform;
         }
      }
   }

   private void Shooting()
   {
      if (closestEnemy == null) return;
      timeSinceLastShot += Time.fixedDeltaTime;
      if (timeSinceLastShot >= fireRate)
      {
         Shoot();
         timeSinceLastShot = 0;
      }
   }

   private void Shoot()
   {
      var muzzleGo = Instantiate(muzzle, muzzlePosition.position, transform.rotation);
      muzzleGo.transform.SetParent(transform);
      Destroy(muzzleGo,0.05f);
      anim.SetTrigger("shoot");

      var projectileGo = Instantiate(projectile, muzzlePosition.position, transform.rotation);
      Destroy(projectileGo,3);
   }

   public void SetOffset(Vector2 o)
   {
      offset = o;
   }
}

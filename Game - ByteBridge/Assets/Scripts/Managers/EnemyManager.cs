using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeBetweenSpawns = 1f;
    private float currentTimeBetweenSpawns;

    private Transform enemiesParent;
    public static EnemyManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        enemiesParent = GameObject.Find("Enemies").transform;
    }

    private void Update()
    {
        currentTimeBetweenSpawns -= Time.fixedDeltaTime;
        if (currentTimeBetweenSpawns <= 0)
        {
            SpawnEnemy();
            currentTimeBetweenSpawns = timeBetweenSpawns;
        }
    }

    private Vector2 RandomPosition()
    {
        return new Vector2(Random.Range(-16, 16), Random.Range(-8,8));
    }

    private void SpawnEnemy()
    {
        var e = Instantiate(enemyPrefab, RandomPosition(), Quaternion.identity);
        e.transform.SetParent(enemiesParent);
    }

    public void DestroyAllEnemies()
    {
        foreach (Transform e in enemiesParent) 
            Destroy(e.gameObject);
    }
}

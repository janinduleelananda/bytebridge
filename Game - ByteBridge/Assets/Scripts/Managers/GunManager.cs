using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] private GameObject gunPrefab;
    private Transform player;
    private List<Vector2> gunPositions = new List<Vector2>();
    private int spawnedGuns = 0;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        
        gunPositions.Add(new Vector2(-1.2f,0.2f));
        gunPositions.Add(new Vector2(1.2f,0.2f));
        gunPositions.Add(new Vector2(-1.4f,-0.4f));
        gunPositions.Add(new Vector2(1.4f,-0.4f));
        gunPositions.Add(new Vector2(-1f,-0.9f));
        gunPositions.Add(new Vector2(1f,-0.9f));
        
        AddGun();
        AddGun();
        AddGun();
        AddGun();
        AddGun();
        AddGun();

        
    }

    void AddGun()
    {
        var pos = gunPositions[spawnedGuns];
        var newGun = Instantiate(gunPrefab, pos, Quaternion.identity);
        
        newGun.GetComponent<Gun>().SetOffset(pos);
        spawnedGuns++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // basics
    [SerializeField] public int movementSpeed = 5;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int luck = 1;
    
    // modifiers all percentage values
    [SerializeField] public float fireRateModifier = 1f;
    [SerializeField] public float critStat = 0f;
    [SerializeField] public float movementSpeedModifier = 1f;
    [SerializeField] public float maxHealthModifier = 1f;
    [SerializeField] public float luckModifier = 1f;
    [SerializeField] public float rangeModifier = 1f;
    [SerializeField] public float damageModifier = 1f;
    
    
    public static PlayerManager Instance;
    public void Awake()
    {
        if (Instance == null) Instance = this;
    }
    
    
    
}

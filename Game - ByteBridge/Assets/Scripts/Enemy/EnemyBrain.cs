using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float speed = 2f;
    private int currentHealth;
    private Animator anim;
    private Transform target;
    
    private void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();
            transform.position += direction * (speed * Time.fixedDeltaTime);
        }

        var playertoright = target.position.x > transform.position.x;
        transform.localScale = new Vector2(playertoright ? -1 : 1, 1);
    }

    public void Hit(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("hit");
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.gameObject.GetComponent<EnemyBrain>();
        if (enemy != null)
        {
            Destroy(gameObject);
            enemy.Hit(25);
        }
    }
}

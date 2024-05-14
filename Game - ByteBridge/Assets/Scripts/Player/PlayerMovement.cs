using System;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    private Animator anim;
    private Rigidbody2D rb;

    private int currentHealth;

    private bool dead = false;
    private float moveHorizontal, moveVertical;
    private Vector2 movement;
    private PlayerManager _playerManager;
    private int facingDirection = 1;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _playerManager = PlayerManager.Instance;

        currentHealth = _playerManager.maxHealth;
        healthText.text = currentHealth.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hit(10);
        }
        if (dead)
        {
            movement = Vector2.zero;
            anim.SetFloat("Velocity",0);
            return;
        }

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical).normalized;
        
        anim.SetFloat("Velocity",movement.magnitude);

        if (movement.x !=0)
        {
            facingDirection = movement.x > 0 ? 1 : -1;
        }

        transform.localScale = new Vector2(facingDirection, 1);
        
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * (_playerManager.movementSpeed * _playerManager.movementSpeedModifier);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyBrain enemy = collision.gameObject.GetComponent<EnemyBrain>();
        if (enemy != null)
        {
            Hit(20);
        }
    }

    void Hit(int damage)
    {
        anim.SetTrigger("hit");
        currentHealth -= damage;
        healthText.text = Mathf.Clamp(currentHealth, 0, _playerManager.maxHealth).ToString();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        dead = true;
    }
}

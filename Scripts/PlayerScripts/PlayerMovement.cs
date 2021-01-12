using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int health = 100;
    private int currentHealth;
    public HealthBar healthBar;
    public Animator animator;
    public float movementSpeed = 5f;
    public FixedJoystick joystick;
    private Vector2 movement;

    public GameObject gameOverMenu;

    void Start()
    {
        healthBar.SetMaxHealth(health);
        currentHealth = health;

    }
    // Update is called once per frame
    void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        animator.SetFloat("Horizontal",movement.normalized.x);
        animator.SetFloat("Vertical",movement.normalized.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);    
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            GameOver();
        }
        healthBar.SetHealth(currentHealth);
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Gold1"))
        {
            //update score
            GameManager.score += 1;
            Destroy(collider.gameObject);
        }
        else if(collider.CompareTag("Gold2"))
        {
            GameManager.score += 2;
            Destroy(collider.gameObject);
        }
        else if(collider.CompareTag("Gold3"))
        {
            GameManager.score += 3;
            Destroy(collider.gameObject);
        }
        else if(collider.CompareTag("Gold4"))
        {
            GameManager.score += 4;
            Destroy(collider.gameObject);
        }
        else if(collider.CompareTag("Gold5"))
        {
            GameManager.score += 5;
            Destroy(collider.gameObject);
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        GameObject.FindGameObjectWithTag("UI").SetActive(false);
        gameOverMenu.SetActive(true);
    }
}

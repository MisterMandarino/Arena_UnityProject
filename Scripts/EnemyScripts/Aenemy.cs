using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Aenemy : MonoBehaviour
{
    //attributi
    public HealthBar healthBar;
    protected int currentHealth;
    private int health;
    private float speed;
    protected Transform playerTarget;
    public Animator animator;
    protected Vector2 animatorController;

    public GameObject[] projectiles;
    public GameObject[] drops;



    //metodi astratti
    public abstract void Movement();
    public abstract void Shooting();
    public abstract void AnimatorController();

    //metodi
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    public bool IsDeath()
    {
        if(currentHealth <= 0)
            return true;
        else
            return false;
    }

    public virtual void DropGold()
    {
        if(IsDeath())
        {
            int randomGold = Random.Range(0,drops.Length);
            Instantiate(drops[randomGold],transform.position,Quaternion.identity);
            Destroy(gameObject); 
        }
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public int GetHealth()
    {
        return this.health;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return this.speed;
    }
}

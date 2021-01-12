using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleEnemy : Aenemy
{
    public int turtleHealth = 80;
    public float turtleSpeed = 5f;
    public int damage = 5;
    private float currentTime = 0f;
    public float standTime = 3f;
    private Vector2 targetPos;
    private bool oneDrop = true;
    
    void Start()
    {
        SetHealth(turtleHealth);
        SetSpeed(turtleSpeed);

        healthBar.SetMaxHealth(GetHealth());
        currentHealth = GetHealth();

        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        targetPos = playerTarget.position;
    }

    void Update()
    {
        if(!IsDeath())
            Movement();
            
        AnimatorController();

        DropGold();
    }

    public override void Movement()
    {
        if(currentTime <= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position,targetPos,GetSpeed()* Time.deltaTime);
                if(Vector2.Distance(transform.position,targetPos) <= 0)
                {
                    currentTime = standTime;
                }
            }
            else
            {
                if(currentTime <= 0.5)
                {
                    targetPos = playerTarget.position;
                }
                currentTime -= Time.deltaTime;
            }
    }

    public override void Shooting()
    {
        throw new System.NotImplementedException();
    }

    public override void AnimatorController()
    {
        if(!IsDeath())
        {
            animatorController.x = playerTarget.position.x - transform.position.x;
            animatorController.y = playerTarget.position.y - transform.position.y;
            animatorController.Normalize();
            animator.SetFloat("Horizontal", animatorController.x);
            animator.SetFloat("Vertical", animatorController.y);
        }
        else
            animator.SetBool("isDeath",true);
    }

    public override void DropGold()
    {
        if(IsDeath())
        {
            int randomGold = Random.Range(0,drops.Length);
            if(oneDrop)
            {
                Instantiate(drops[randomGold],transform.position,Quaternion.identity);
                oneDrop = false;
            }
            Destroy(gameObject,2f); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().TakeDamage(damage);
        }
    }
}

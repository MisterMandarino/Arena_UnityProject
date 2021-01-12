using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : Aenemy
{
    public int ghostHealth = 30;
    public float ghostSpeed = 2f;
    public float teleportTime = 4f;
    public float stopDistance = 3f;
    private float currentTeleport = 0f;

    void Start()
    {
        SetHealth(ghostHealth);
        SetSpeed(ghostSpeed);

        healthBar.SetMaxHealth(GetHealth());
        currentHealth = GetHealth();

        currentTeleport = teleportTime;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        Movement();
        AnimatorController();

        DropGold();
    }

    public override void Movement()
    {
        if(currentTeleport <= 0)
        {
            Vector2 temp = playerTarget.position;
            temp += Random.insideUnitCircle.normalized * stopDistance;

            transform.position = temp;

            currentTeleport = teleportTime;
            Shooting();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, -GetSpeed() * Time.deltaTime);
            currentTeleport -= Time.deltaTime;
        }
    }

    public override void Shooting()
    {
        Instantiate(projectiles[0],transform.position,Quaternion.identity);
    }

    public override void AnimatorController()
    {
        animatorController.x = playerTarget.position.x - transform.position.x;
        animatorController.y = playerTarget.position.y - transform.position.y;
        animatorController.Normalize();
        animator.SetFloat("Horizontal", animatorController.x);
        animator.SetFloat("Vertical", animatorController.y);
        animator.SetFloat("Speed",1f);

    }
}

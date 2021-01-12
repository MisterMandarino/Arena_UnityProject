using UnityEngine;

public class SkeletonEnemy : Aenemy
{
    public int skeletonHealth = 50;
    public float skeletonSpeed = 3f;
    public float stopDistance = 5f;
    private float timeShot;
    public float shootingTime;


    void Start()
    {
        SetSpeed(skeletonSpeed);
        SetHealth(skeletonHealth);
        
        healthBar.SetMaxHealth(GetHealth());
        currentHealth = GetHealth();


        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        timeShot = shootingTime;
    }

    void Update()
    {
        Movement();
        AnimatorController();
        Shooting();

        DropGold();
    }

    public override void Movement()
    {
        if(Vector2.Distance(transform.position,playerTarget.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, GetSpeed() * Time.deltaTime);
        }

    }

    public override void Shooting()
    {
        if(timeShot <= 0)
        {
            Instantiate(projectiles[0],transform.position,Quaternion.identity);
            timeShot = shootingTime;
        }
        else
        {
            timeShot -= Time.deltaTime;
        }
    }

    public override void AnimatorController()
    {
        if(Vector2.Distance(transform.position,playerTarget.position) > stopDistance)
        {
            animatorController.x = playerTarget.position.x - transform.position.x;
            animatorController.y = playerTarget.position.y - transform.position.y;
            animatorController.Normalize();

            animator.SetFloat("Horizontal",animatorController.x);
            animator.SetFloat("Vertical",animatorController.y);
            animator.SetFloat("Speed",1f);
        }
        else
            animator.SetFloat("Speed",0f);

    }
}

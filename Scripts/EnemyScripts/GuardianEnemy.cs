using UnityEngine;

public class GuardianEnemy : Aenemy
{
    public int guardianHealth = 120;
    public float guardianSpeed = 3f;
    private float range = 6f;
    public int projectileNumber = 3;

    private float timeShot;
    public float shootingTime;
    private bool oneDrop = true;

    void Start()
    {
        SetSpeed(guardianSpeed);
        SetHealth(guardianHealth);

        healthBar.SetMaxHealth(GetHealth());
        currentHealth = GetHealth();

        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        timeShot = shootingTime;
    }

    void Update()
    {
        Movement();
        Shooting();
        AnimatorController();
        DropGold();
    }

    public override void AnimatorController()
    {
        animatorController.x = playerTarget.position.x - transform.position.x;
        animatorController.y = playerTarget.position.y - transform.position.y;
        animatorController.Normalize();

        animator.SetFloat("Horizontal",animatorController.x);
        animator.SetFloat("Vertical",animatorController.y);

        if(IsDeath())
        {
            animator.SetBool("isDeath",true);
        }
        else
        {
            animator.SetBool("isDeath", false);
        }
    }

    public override void Shooting()
    {
        if(timeShot <= 0 && (!IsDeath()))
        {
            for(int i = 0; i < projectileNumber; i++)
            {
                Instantiate(projectiles[0],transform.position,Quaternion.identity);
            }

            timeShot = shootingTime;
        }
        else
        {
            timeShot -= Time.deltaTime;
        }
    }

    public override void Movement()
    {
        if(!IsDeath())
        {
            if(Vector2.Distance(transform.position,playerTarget.position) > range)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTarget.position,2* GetSpeed() * Time.deltaTime);
            }
            else
                transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, 0.5f *GetSpeed() * Time.deltaTime);
        }
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
}

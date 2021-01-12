using UnityEngine;

public class RedProjectile : AbstractEnemyProjectile
{
    public int bulletDamage = 15;
    public float bulletSpeed = 12f;

    void Start()
    {
        SetDamage(bulletDamage);
        SetSpeed(bulletSpeed);

        if(Random.Range(1,6) == 1)
        {
            gameObject.transform.localScale = gameObject.transform.localScale * 2;
            SetDamage(bulletDamage * 2);
        }
        else
        {
            SetDamage(bulletDamage);
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x,player.position.y);
    }

    void Update()
    {
        ProjectilePath();
    }

    public override void ProjectilePath()
    {
        transform.position = Vector2.MoveTowards(transform.position,target,GetSpeed() * Time.deltaTime);
        if(Vector2.Distance(transform.position,target) == 0)
            Destroy(gameObject);
    }
}

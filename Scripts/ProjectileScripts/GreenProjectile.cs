using UnityEngine;

public class GreenProjectile : AbstractEnemyProjectile
{
    public int bulletDamage = 30;
    void Start()
    {
        SetDamage(bulletDamage);
        SetSpeed(Random.Range(1,6));

        target = Random.insideUnitCircle.normalized * 100;

        Destroy(gameObject,10f);
    }

    void Update()
    {
        ProjectilePath();
    }

    public override void ProjectilePath()
    {
        transform.position = Vector2.MoveTowards(transform.position,target,GetSpeed() * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueProjectile : AbstractEnemyProjectile
{
    public int bulletDamage = 10;
    public float bulletSpeed = 3f;
    public float bulletLifeTime = 4f;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        SetDamage(bulletDamage);
        SetSpeed(bulletSpeed);
        SetLifeTime(bulletLifeTime);

        angle = 0f;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;
        Destroy(gameObject,GetLifeTime());
    }

    // Update is called once per frame
    void Update()
    {
        ProjectilePath();
    }

    public override void ProjectilePath()
    {
        if(angle >= 360)
            angle = 0f;
        else
            angle += 0.1f;
        
        if(Random.Range(0,1) == 0)
            transform.position = Vector2.MoveTowards(transform.position,target * Mathf.Sin(angle) * 5,GetSpeed() * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position,target * Mathf.Cos(angle) * 5,GetSpeed() * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractProjectile : MonoBehaviour
{
    private int damage;
    private float speed;
    private float lifeTime;

    public abstract void ProjectilePath();
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public int GetDamage()
    {
        return this.damage;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return this.speed;
    }

    public void SetLifeTime(float lifeTime)
    {
        this.lifeTime = lifeTime;
    }

    public float GetLifeTime()
    {
        return this.lifeTime;
    }


    
}

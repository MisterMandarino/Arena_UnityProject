using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGreen : AbstractPlayerProjectile
{
    public int bulletDamage = 30;
    public float bulletLifeTime = 0.5f;
    void Start()
    {
        SetDamage(bulletDamage);
        SetLifeTime(bulletLifeTime);
        Destroy(gameObject,GetLifeTime());
    }

    

    public override void ProjectilePath()
    {
        throw new System.NotImplementedException();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayerProjectile : AbstractProjectile
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Aenemy>().TakeDamage(GetDamage());
            Destroy(gameObject);
        }
    }
}

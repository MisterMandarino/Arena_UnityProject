using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemyProjectile : AbstractProjectile
{
    protected Transform player;
    protected Vector2 target;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().TakeDamage(GetDamage());
            Destroy(gameObject);
        }
    }
}

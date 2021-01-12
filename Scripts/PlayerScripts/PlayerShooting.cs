using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public FixedJoystick joystick;
    public float bulletForce = 20f;
    public Animator animator;
    public float timeBetweenShots = 3f;
    private float shootingTime = 0f;
    
    float angle;
    Vector2 shootingPos;
    
    void Update()
    {
        if((Mathf.Abs(joystick.Horizontal) > 0.2f || Mathf.Abs(joystick.Vertical) > 0.2f) && shootingTime <= 0)
        {
            shootingPos.x = joystick.Horizontal;
            shootingPos.y = joystick.Vertical;
            
            animator.SetBool("Shooting",true);
            animator.SetFloat("ShootH",shootingPos.normalized.x);
            animator.SetFloat("ShootV",shootingPos.normalized.y);

            shootingPos.Normalize();

            angle = Mathf.Atan2(shootingPos.y,shootingPos.x) * Mathf.Rad2Deg -180f;
            Shoot();
            shootingTime = timeBetweenShots;

        }
        else
        {
            animator.SetBool("Shooting",false);
            shootingTime -= Time.deltaTime;
        }
        
    }

    private void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("ArrowShot");
        
        GameObject bullet = Instantiate(bulletPrefab,transform.position,transform.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.rotation = angle;
        bulletRB.AddForce(shootingPos * bulletForce,ForceMode2D.Impulse);
    }
}

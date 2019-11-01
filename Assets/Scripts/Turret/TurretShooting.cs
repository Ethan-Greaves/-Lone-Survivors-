using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform movingTurret;
    [SerializeField] Enemy enemy;
    [SerializeField] Projectile projectile;

    [Header("Turret Config")]
    [SerializeField] float attackRange = .5f;
    [SerializeField] float fireRate = 2;

    private float fireDelay;

    void Start()
    {
        //We want the first shot to shoot straight away
        fireDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FindEnemy();
    }

    private void FindEnemy()
    {
        //If the distance between turret & enemy is less than turrets range
        if (Vector2.Distance(transform.position, enemy.transform.position) < attackRange)
        {
            //Look at enemy
            movingTurret.LookAt(enemy.transform.position);
            transform.right = enemy.transform.position - transform.position;

            Shoot();
        }
    }

    private void Shoot()
    {
        fireDelay -= Time.deltaTime;

        if (fireDelay <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);

            //Reset the delay
            fireDelay = fireRate;
        }
    }
}

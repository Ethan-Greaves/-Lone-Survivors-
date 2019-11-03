using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform movingTurret;
    [SerializeField] Projectile projectile;
    [SerializeField] Transform barrel;

    [Header("Turret Config")]
    [SerializeField] float attackRange = .5f;
    [SerializeField] float fireRate = 2;

    private Enemy enemy;
    private float fireDelay;

    void Start()
    {
        //We want the first shot to shoot straight away
        fireDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
        LookAtClosestEnemy();
    }

    private void FindClosestEnemy()
    {
        //Find every enemy currently in the scene
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        //If there are no enemies present 
        if(enemies.Length == 0)
        {
            return;
        }
        else
        {
            //Get the first enemy
            Enemy closestEnemy = enemies[0];

            //Calculate its distance from the turret
            var closestEnemyDistance = Vector2.Distance(transform.position, closestEnemy.transform.position);

            //Loop through every enemy in the scene currently
            for (int i = 0; i < enemies.Length; i++)
            {
                //If the distance of enemy[i] is less than the distance of the closest enemy
                if(Vector2.Distance(transform.position, enemies[i].transform.position) < closestEnemyDistance)
                {
                    //That enemy is now the closest enemy
                    closestEnemy = enemies[i];

                    //Shortest distance is now the distance of the new closest enemy
                    closestEnemyDistance = Vector2.Distance(transform.position, enemies[i].transform.position);
                }
            }

            //Set the closest enemy to be the enemy the turret looks at
            enemy = closestEnemy;
        }
    }

    private void LookAtClosestEnemy()
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
            Instantiate(projectile, barrel.transform.position, barrel.rotation);

            //Reset the delay
            fireDelay = fireRate;
        }
    }
}


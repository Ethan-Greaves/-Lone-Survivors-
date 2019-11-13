using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float minSpawnTime = 2f;
    [SerializeField] float maxSpawnTime = 4f;
    [SerializeField] Enemy[] enemies;

    float randomSpawnTime;
    Vector3 randomPathWidth;

    // Start is called before the first frame update
    void Start()
    {
        randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        randomPathWidth = new Vector3(Random.Range(transform.position.x - 1, transform.position.x + 1), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        //Count down random timer
        randomSpawnTime -= Time.deltaTime;

        if(randomSpawnTime <= 0)
        {
            //Spawn random enemy
            Instantiate(enemies[Random.Range(0, enemies.Length)], randomPathWidth, Quaternion.identity);

            //Reset the spawnTime and pathWidth per enemy
            randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            randomPathWidth = new Vector3(Random.Range(transform.position.x - 0.7f, transform.position.x + 0.7f), transform.position.y, transform.position.z);
        }
    }
}

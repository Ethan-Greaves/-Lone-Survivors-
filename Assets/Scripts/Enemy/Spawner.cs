using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float minSpawnTime = 2f;
    [SerializeField] float maxSpawnTime = 4f;
    [SerializeField] GameObject[] objectsToSpawn;
    [SerializeField] float spawnOffsetX = 0.5f;
    [SerializeField] float spawnOffsetY = 0.5f;

    float randomSpawnTime;
    Vector3 randomPathWidth;

    // Start is called before the first frame update
    void Start()
    {
        randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        randomPathWidth = new Vector3(Random.Range(transform.position.x - spawnOffsetX, transform.position.x + spawnOffsetX),
                                      Random.Range(transform.position.y - spawnOffsetY, transform.position.y + spawnOffsetY),
                                                   transform.position.z);
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
            Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], randomPathWidth, Quaternion.identity);

            //Reset the spawnTime and pathWidth per enemy
            randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            randomPathWidth = new Vector3(Random.Range(transform.position.x - spawnOffsetX, transform.position.x + spawnOffsetX),
                                          Random.Range(transform.position.y - spawnOffsetY, transform.position.y + spawnOffsetY), 
                                                       transform.position.z);
        }
    }
}

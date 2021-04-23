using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerUp;
    public GameObject rock;

    private float xSpawnRange = 24.0f;
    private float zSpawnRange = 13.0f;
    private float ySpawnEnemies = 2.1f;
    private float ySpawnRock = 1.0f;

    private float enemySpawnTimer = 15.0f;
    private float rockSpawnTimer = 10.0f;
    private float powerUpSpawnTimer = 30.0f;
    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnRandomEnemy();
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTimer);
        InvokeRepeating("SpawnRock", startDelay, rockSpawnTimer);
        InvokeRepeating("SpawnPowerUp", startDelay, powerUpSpawnTimer);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zSpawnRange, zSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawnEnemies, randomZ);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnRock()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zSpawnRange, zSpawnRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawnRock, randomZ);

        Instantiate(rock, spawnPos, rock.gameObject.transform.rotation);
    }

    void SpawnPowerUp()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zSpawnRange, zSpawnRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawnRock, randomZ);

        Instantiate(powerUp, spawnPos, rock.gameObject.transform.rotation);
    }
}

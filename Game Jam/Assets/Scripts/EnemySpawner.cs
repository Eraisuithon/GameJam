using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public float timer = 0;


    // Update is called once per frame
    void Update()
    {
        int seconds = 2; // Every 2 seconds enemy spawns
        if (timer > seconds) 
        {
            timer -= seconds;
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoints = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoints].position, transform.rotation);
        }
        timer += Time.deltaTime;

    }
}

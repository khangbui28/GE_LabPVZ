using System.Collections.Generic;
using UnityEngine;


public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints; 
    [SerializeField] Zombie[] zombiePrefabs; 
    
    [SerializeField] float initialSpawnInterval = 1f; 
    [SerializeField] float spawnRateIncrease = 0.5f; 
    private float currentSpawnInterval;
    private float currentTime;
    
    private List<Zombie> activeZombies = new List<Zombie>();
    [SerializeField] int maxZombies = 100;
    private void Awake()
    {
        activeZombies.Clear();
    }

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        currentTime = currentSpawnInterval;

       
    }

    private void Update()
    {
        
        currentTime -= Time.deltaTime;

        if (currentTime <= 0 && activeZombies.Count < maxZombies)
        {
            Spawn();
            currentTime = currentSpawnInterval;

            currentSpawnInterval = Mathf.Max(0.5f, currentSpawnInterval - spawnRateIncrease);
        }

       
    }

    public void Spawn()
    {
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Zombie randomZombie = zombiePrefabs[Random.Range(0, zombiePrefabs.Length)];
        Zombie z =  Instantiate(randomZombie, randomSpawnPoint.position, Quaternion.identity);

        activeZombies.Add(z);
    }
}



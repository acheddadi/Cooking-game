using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{

    [SerializeField] float spawnTime, spawnTimer, difficulty = 2, maxDifficulty = 5;

    public GameObject CustomerPrefab;

    public Transform spawn;


    private void Start()
    {
        spawnTime = 10f / difficulty;
    }

    private void Update()
    {
        if (spawnTimer > spawnTime)
        {
            Instantiate(CustomerPrefab, spawn.position, Quaternion.identity);
            difficulty += 0.10f;
            if (difficulty > maxDifficulty) difficulty = 5f;
            spawnTime = 10f / difficulty;
            spawnTimer = 0.0f;
        }

        spawnTimer += Time.deltaTime;
    }

}

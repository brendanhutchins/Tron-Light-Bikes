using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject coinPrefab;
    private float spawnRange = 64;

    private float spawnPosX;
    private float spawnPosY;
    Vector3 spawnPos;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private Move playerController;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoin", startDelay, spawnInterval);
        playerController = GameObject.Find("Player").GetComponent<Move>();
    }

    void SpawnCoin()
    {
        if (playerController.gameOver == false)
        {
            // Randomly generate coin spawn position
            spawnPosX = Random.Range(-spawnRange, spawnRange);
            spawnPosY = Random.Range(-spawnRange, spawnRange);

            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
            Instantiate(coinPrefab, spawnPos, Quaternion.Euler(0, 0, 0));
        }
    }
}

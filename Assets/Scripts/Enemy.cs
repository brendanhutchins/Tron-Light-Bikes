using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LightBike
{
    // Wall Prefab
    public GameObject wallPrefab;

    private float lastSpeed = 16;
    private CurrentDirection direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = ChangeBikeDirection(startDirection);
        SpawnWall(wallPrefab);
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if (lastSpeed != speed)
        {
            ChangeBikeDirection(direction);
            lastSpeed = speed;
        }

        if (isInputEnabled)
        {
            FitColliderBetween(wall, lastWallEnd, transform.position);
        }
    }

    public void ChangeSpeed(int speed)
    {
        this.speed = speed;
        ChangeBikeDirection(direction);
        SpawnWall(wallPrefab);
    }

    public void ChangeDirection(string direction)
    {
        if (isInputEnabled)
        {
            try
            {
                CurrentDirection currentDirection = ChangeBikeDirection((CurrentDirection)Enum.Parse(typeof(CurrentDirection), direction));
                this.direction = currentDirection;
                SpawnWall(wallPrefab);
            }
            catch
            {
                Debug.LogError("Signal asset string not found in direction enum!");
            }
        }
    }
}

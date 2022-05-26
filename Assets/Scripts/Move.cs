using System;
using UnityEngine;

public class Move : LightBike
{
    // Movement keys (customizable in Inspector)
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    // Wall Prefab
    public GameObject wallPrefab;
    public bool gameOver = false;

    private float lastSpeed = 16;

    //public int score;

    private bool turned = false;
    private float decay = 0.05f;

    private CurrentDirection direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = ChangeBikeDirection(startDirection);
        SpawnWall(wallPrefab);
        material = GetComponent<SpriteRenderer>().material;
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

    //
    // Update is called once per frame
    void Update()
    {
        if (lastSpeed != speed)
        {
            ChangeBikeDirection(direction);
            lastSpeed = speed;
        }
        // Check for key presses
        if (isInputEnabled)
        {
            // Up
            //if (Input.GetKeyDown(upKey) && direction != CurrentDirection.Up && direction != CurrentDirection.Down && !turned)
            //{
            //    decay = 0.1f;

            //    direction = ChangeBikeDirection(CurrentDirection.Up);
            //    SpawnWall(wallPrefab);
            //}
            //// Down
            //else if (Input.GetKeyDown(downKey) && direction != CurrentDirection.Down && direction != CurrentDirection.Up && !turned)
            //{
            //    decay = 0.1f;

            //    direction = ChangeBikeDirection(CurrentDirection.Down);
            //    SpawnWall(wallPrefab);
            //}
            //// Right
            //else if (Input.GetKeyDown(rightKey) && direction != CurrentDirection.Right && direction != CurrentDirection.Left && !turned)
            //{
            //    decay = 0.1f;

            //    direction = ChangeBikeDirection(CurrentDirection.Right);
            //    SpawnWall(wallPrefab);
            //}
            //// Left
            //else if (Input.GetKeyDown(leftKey) && direction != CurrentDirection.Left && direction != CurrentDirection.Right && !turned)
            //{
            //    decay = 0.1f;

            //    direction = ChangeBikeDirection(CurrentDirection.Left);
            //    SpawnWall(wallPrefab);
            //}

            FitColliderBetween(wall, lastWallEnd, transform.position);
        }
    }

    private void Reset()
    {
        if (turned && decay > 0)
        {
            decay -= Time.deltaTime;
        }
        if (decay < 0)
        {
            decay = 0;
            turned = false;
        }
    }
}

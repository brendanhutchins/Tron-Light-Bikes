using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBike : MonoBehaviour
{
    public float speed = 16;

    public CurrentDirection startDirection;

    // Current Wall
    protected Collider2D wall;

    // Last Wall's End
    protected Vector2 lastWallEnd;

    protected Material material;

    protected bool isInputEnabled = true;

    // List of walls
    private List<GameObject> wallObjects = new List<GameObject>();

    private float fade = 1f;

    private bool isHit = false;

    protected void SpawnWall(GameObject wallPrefab)
    {
        // Save last wall's position
        lastWallEnd = transform.position;

        // Spawn a new Lighwall
        GameObject g = Instantiate(wallPrefab, transform.position, Quaternion.identity);
        wallObjects.Add(g);
        wall = g.GetComponent<Collider2D>();
    }

    
    private void OnTriggerEnter2D(Collider2D co)
    {
        // If intersecting with coin
        if (co.gameObject.tag == "Coin")
        {
            Destroy(co.gameObject);
            speed += 2;
            // If player object picks up coin
            if (gameObject.tag == "Player")
            {
                GameManager.score += 100;
            }
        }

        // If object is oil
        else if (co.gameObject.tag == "Oil")
        {
            Destroy(co.gameObject);
            speed -= 4;
        }

        // If object is turn marker
        else if (co.gameObject.tag == "Turner")
        {
            CurrentDirection temp = co.gameObject.GetComponent<TurnPlayer>().direction;
            if (gameObject.tag == "Player")
            {
                gameObject.GetComponent<Move>().ChangeDirection(temp.ToString());
            }
            else
            {
                gameObject.GetComponent<Enemy>().ChangeDirection(temp.ToString());
            }
        }

        // Not the current wall?
        else if (co != wall)
        {
            print("Player lost: " + name);
            print(co.gameObject);
            if (gameObject.tag == "Player")
            {
                gameObject.GetComponent<Move>().gameOver = true;
            }

            isInputEnabled = false; // disable all inputs

            // Fade out object and destroy it
            if (!isHit)
            {
                StartCoroutine("Fade");
                isHit = true;
            }
        }
    }

    protected void FitColliderBetween(Collider2D co, Vector2 a, Vector2 b)
    {
        // Calculate the Center Position
        co.transform.position = a + (b - a) * 0.5f;

        // Scale it (horizontally or vertically)
        float dist = Vector2.Distance(a, b);
        if (a.x != b.x)
        {
            co.transform.localScale = new Vector2(dist + 1, 1);
        }
        else
        {
            co.transform.localScale = new Vector2(1, dist + 1);
        }
    }

    // Starting Bike Direction
    protected CurrentDirection ChangeBikeDirection(CurrentDirection direction)
    {
        // Starting direction of bike
        switch (direction)
        {
            case CurrentDirection.Up:
                GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case CurrentDirection.Down:
                GetComponent<Rigidbody2D>().velocity = -Vector2.up * speed;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case CurrentDirection.Right:
                GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            case CurrentDirection.Left:
                GetComponent<Rigidbody2D>().velocity = -Vector2.right * speed;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }
        return direction;
    }

    IEnumerator Fade()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            fade = ft;
            material.SetFloat("_Fade", fade);
            yield return new WaitForSeconds(.1f);
        }

        Destroy(gameObject);
        if (GameObject.Find("Player") != null && gameObject.tag != "Player")
        {
            GameManager.score += 10000;
        }
        for (int i = 0; i < wallObjects.Count; i++)
        {
            Destroy(wallObjects[i]);
        }
        wallObjects.Clear();
    }
}

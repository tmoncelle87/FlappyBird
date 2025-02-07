using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2; // Default spawn rate
    private float timer = 0;
    public float heightOffset = 10;

    void Start()
    {
        spawnPipe(); // Initial pipe spawn
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            spawnPipe();
            timer = 0;
        }

        AdjustSpawnRate(); // Call this every frame to check the score
    }

    void AdjustSpawnRate()
    {
        // Access the static playerScore from BirdScript directly
        if (BirdScript.playerScore >= 150)
        {
            spawnRate = 1.5f;
        }
        else if (BirdScript.playerScore >= 100)
        {
            spawnRate = 2f;
        }
        else if (BirdScript.playerScore >= 50)
        {
            spawnRate = 3f;
        }
        else if (BirdScript.playerScore >= 25)
        {
            spawnRate = 3f;
        }
        else if (BirdScript.playerScore >= 10)
        {
            spawnRate = 4f;
        }
        else if (BirdScript.playerScore >= 5)
        {
            spawnRate = 4.5f;
        }
        else
        {
            spawnRate = 5f; // Default spawn rate
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
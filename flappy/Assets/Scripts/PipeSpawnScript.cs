using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipeObject1;
    public GameObject pipeObject2;
    public GameObject pipeGap;
    public float spawnRate = 2; // Default spawn rate
    private float timer = 0;
    public float topPipeYValue =10;
    public float YValue = 0f;
    public int lastMilestone = 0;

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

        int milestone = BirdScript.playerScore / 10;

        if (milestone > lastMilestone)
        {
            lastMilestone = milestone;

            YValue += 1f; // or any other change you'd like to apply
        }

    }




    void AdjustSpawnRate()
    {
        float baseSpawnRate = Mathf.Lerp(5f, 0.5f, BirdScript.playerScore / 100f);
        spawnRate = UnityEngine.Random.Range(baseSpawnRate - 0.25f, baseSpawnRate + 0.25f);
        // Access the static playerScore from BirdScript directly
      
    }

    //I want this to spawn a pipe it will spawn twice once on top and once pon bottom of screen. they will bpoth spawn at the same tiome due to the spawn pipe function
    void spawnPipe()
    {
        Instantiate(pipeGap, new Vector3(transform.position.x + 10, 0, 0), Quaternion.identity);
        Instantiate(pipeObject1, new Vector3(transform.position.x + 10, -19 + YValue, 0), Quaternion.identity);
        Instantiate(pipeObject2, new Vector3(transform.position.x + 10, 19 - YValue, 0), Quaternion.Euler(0, 0, 180));

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipeObject1;
    public GameObject pipeObject2;
    public GameObject pipeGap;
    public float spawnRate = 4.5f; // Default spawn rate
    private float timer = 0;
    public float minTopPipeValue = 11f;
    public float lastPipe1YPosition;
    public float maxTopPipeValue = 21f;
    public float CurrentTopPipeYLevel;
    public float CurrentBottomPipeYLevel;
    private float direction = -1; // -1 means move downward, +1 means move upward

    void Start()
    {

        CurrentBottomPipeYLevel = -21f;
        CurrentTopPipeYLevel = 21f;
        spawnPipe(); // Initial pipe spawn
    }

    void Update()
    {
        AdjustSpawnRate();

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            spawnPipe();
            timer = 0;
        }

    }


    void AdjustSpawnRate()
    {
        float t = Mathf.Clamp01(BirdScript.playerScore / 50f);
        spawnRate = Mathf.Lerp(4.5f, 2.5f, t);
    }
    private bool isFirstSpawn = true;
    void spawnPipe()
    {
        Vector3 spawnPos = new Vector3(transform.position.x + 10, 0, 0);
        if (!isFirstSpawn)
        {
            float nextTopY = CurrentTopPipeYLevel + direction;

            if (nextTopY > maxTopPipeValue)
            {
                direction = -0.5f;
            }
            else if (nextTopY > minTopPipeValue && nextTopY < maxTopPipeValue && BirdScript.playerScore > 50)
            {
                direction = -0.25f;
            }
            else if (nextTopY < minTopPipeValue)
            {
                direction = 0.5f;
            }
           

            // Now apply the (possibly reversed) direction
            CurrentTopPipeYLevel += direction;
            CurrentBottomPipeYLevel -= direction;

        }

        else
        {
            isFirstSpawn = false;
        }

        GameObject newGap = Instantiate(pipeGap, spawnPos, Quaternion.identity);
        GameObject newPipe1 = Instantiate(pipeObject1, new Vector3(spawnPos.x, CurrentBottomPipeYLevel, 0), Quaternion.identity);
        GameObject newPipe2 = Instantiate(pipeObject2, new Vector3(spawnPos.x, CurrentTopPipeYLevel, 0), Quaternion.Euler(0, 0, 180));
        Debug.Log(spawnRate);
    }

}
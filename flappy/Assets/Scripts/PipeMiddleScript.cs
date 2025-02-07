using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;      // Reference to the LogicScript.
    public BirdScript birdLogic;   // Reference to the BirdScript.

    void Start()
    {
        // Find the LogicScript component using its tag.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // Find the BirdScript component using its tag.
        birdLogic = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    void Update()
    {
        // Per-frame updates (currently empty).
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is on layer 3 (Bird Layer).
        if (collision.gameObject.layer == 3)
        {
            // Add score using the LogicScript.
            logic.addScore(1);
            //Update the players score
            birdLogic.UpdatePlayerScore(1);
        }
    }
}
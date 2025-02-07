using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 10; // Speed at which the pipe moves to the left.
    public float deadZone = -50;  // X-position at which the pipe is destroyed.

    void Start()
    {
        // Initialization (currently empty).
    }

    void Update()
    {
        // Move the pipe to the left based on moveSpeed and deltaTime.
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // If the pipe has moved past the dead zone, destroy it.
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe deleted"); // Log a message for debugging.
            Destroy(gameObject);      // Destroy the pipe GameObject.
        }
    }
}
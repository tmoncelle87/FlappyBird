using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch_To_Death_Scene : MonoBehaviour
{
    public string sceneBuildIndex; // Name or Build Index of the death scene. Set in the Inspector.

    void Start()
    {
        // Initialization (currently empty).
    }

    void Update()
    {
        // Per-frame updates (currently empty).
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the "Bird" tag.
        if (other.tag == "Bird")
        {
            // Load the death scene using the specified name or build index.
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single); // LoadSceneMode.Single unloads the current scene
        }
    }
}
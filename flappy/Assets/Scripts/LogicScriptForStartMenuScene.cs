using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScriptForStartMenuScene : MonoBehaviour
{
    public string sceneName; // Name of the scene to load. Set in the Inspector.

    void Start()
    {
        // Initialization (currently empty).
    }

    void Update()
    {
        // Per-frame updates (currently empty).
    }

    public void changeScene()
    {
        // Loads the specified scene. Called by UI buttons.
        SceneManager.LoadScene(sceneName);
    }
}
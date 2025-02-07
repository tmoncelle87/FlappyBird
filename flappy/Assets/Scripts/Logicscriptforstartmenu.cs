using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logicscriptforstartmenu : MonoBehaviour
{
    // Name of the scene to load. Set in the Inspector.
    public string sceneName;

    // Called once when the script starts.
    void Start()
    {
    }

    // Called every frame.
    void Update()
    {
    }

    // Loads the specified scene. Called by UI elements.
    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
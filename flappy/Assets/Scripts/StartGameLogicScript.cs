using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameLogicScript : MonoBehaviour
{
    public string sceneStartGame; // Name of the scene to start the game. Set in the Inspector.
    public string sceneOptions;   // Name of the options scene. Set in the Inspector.

    void Start()
    {
        // Initialization (currently empty).
    }

    void Update()
    {
        // Per-frame updates (currently empty).
    }

    public void changeSceneToStartGame()
    {
        // Loads the scene to start the game. Called by UI buttons.
        SceneManager.LoadScene(sceneStartGame);
    }

    public void changeSceneToOptions()
    {
        // Loads the options scene. Called by UI buttons.
        SceneManager.LoadScene(sceneOptions);
    }

    public void QuitGame()
    {
        // Starts a coroutine to quit the game after a delay. Called by UI buttons.
        StartCoroutine(DelayedQuit());
    }

    private IEnumerator DelayedQuit()
    {
        // Provides feedback to the console.
        Debug.Log("Quitting in 1 second...");
        yield return new WaitForSeconds(1f); // Waits for 1 second.

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in the editor.
#else
        Application.Quit(); // Quits the application in a build.
#endif
    }
}
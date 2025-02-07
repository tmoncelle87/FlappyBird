using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsScreenLogicScript : MonoBehaviour
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

    public void buttonClicked()
    {
        // Logs a message to the console. Called by UI buttons.
        Debug.Log("Button was clicked");
    }

    public void QuitGame()
    {
        // Quits the application.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in the editor.
#else
        Application.Quit(); // Quits the application in a build.
#endif
    }
}
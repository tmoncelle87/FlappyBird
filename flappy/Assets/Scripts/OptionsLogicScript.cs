using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OptionsLogicScript : MonoBehaviour
{
    public string PlayGameScnene; // Name of the scene to load. Set in the Inspector.
    public string StartMenuScnene;
    public string CharacterSelectScene;

    void Start()
    {
        // Initialization (currently empty).
    }

    void Update()
    {
        // Per-frame updates (currently empty).
    }

    public void chnageSceneToCharacterSelect()
    {
        SceneManager.LoadScene(CharacterSelectScene);
    }

    public void changeSceneToPlayGame()
    {
        // Loads the specified scene. Called by UI buttons.
        SceneManager.LoadScene(PlayGameScnene);
    }

    public void changeSceneToMainMenu()
    {
        // Loads the specified scene. Called by UI buttons.
        SceneManager.LoadScene(StartMenuScnene);
    }
    public void buttonClicked()
    {
        // Logs a message to the console. Called by UI buttons.
        Debug.Log("Button was clicked");
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

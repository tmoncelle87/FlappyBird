using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectLogicScript : MonoBehaviour
{
    public string optionScreenSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeSceneToOptionScreen()
    {
        SceneManager.LoadScene(optionScreenSceneName);
    }
}

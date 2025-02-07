using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreneLogicScript : MonoBehaviour
{
    public string scenePlayGame;    // Name of the scene to play the game. Set in the Inspector.
    public string sceneOptions;      // Name of the options scene. Set in the Inspector.
    public Text highScoreText;      // Text UI element to display the high score. Set in the Inspector.
    public Text currentScoreText; // Text UI element to display the current score. Set in the Inspector.

    void Start()
    {
        DisplayScores(); // Display both scores when the scene starts
    }

    void Update()
    {
        // Per-frame updates (currently empty).
    }

    public void changeSceneToGame()
    {
        // Loads the game scene. Called by UI buttons.
        SceneManager.LoadScene(scenePlayGame);
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

    private void DisplayScores()
    {
        // Displays both the high score and the current player's score.

        if (highScoreText != null)
        {
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreText.text = highScore.ToString();
        }
        else
        {
            Debug.LogError("High Score Text element not assigned in the Inspector!");
        }

        if (currentScoreText != null)
        {
            int currentScore = BirdScript.playerScore; // Access the static playerScore from BirdScript
            currentScoreText.text = currentScore.ToString();
        }
        else
        {
            Debug.LogError("Current Score Text element not assigned in the Inspector!");
        }
    }
}
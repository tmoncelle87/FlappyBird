using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public int playerScore;        // The player's current score.
    public Text scoreText;         // The Text UI element to display the score. Set in the Inspector.
    public string GameScreen;      // Name of the main game scene.
    public string GameOverScreen;  // Name of the game over scene.
    public static LogicScript Instance; // Static instance of this script (Singleton).

    [ContextMenu("Increase Score")] // Allows calling addScore from the Inspector context menu.
    public void addScore(int scoreToAdd)
    {
        // Adds to the player's score and updates the score text.
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        // Restarts the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        // Loads the game over scene.
        SceneManager.LoadScene(GameOverScreen);
    }

    public void changeToGameOverScene()
    {
        // Loads the game over scene. (Duplicate of gameOver())
        SceneManager.LoadScene(GameOverScreen);
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
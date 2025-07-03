using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;
public class CharacterManagerScript : MonoBehaviour
{
    public string optionScreenSceneName;
    public Transform spawnStartPoint; // Empty GameObject in scene
    public List<ChcratacterTestScript> characters = new List<ChcratacterTestScript>();
    public int Displayed_Character = 0;
    public GameObject currentCharacterInstance;
    public static GameObject SelectedCharacterPrefab;
    void Start()
    {
        DisplayCharacters();
        SelectedCharacterPrefab = characters[Displayed_Character].characterPrefab;
    }
    public void DisplayCharacters()
    {
        
        Vector3 spawnPos = spawnStartPoint.position;
        if (currentCharacterInstance != null)
        {
            Destroy(currentCharacterInstance);
        }

        
        currentCharacterInstance = Instantiate(characters[Displayed_Character].characterPrefab, spawnPos, Quaternion.identity);
        currentCharacterInstance.transform.localScale *= 3f;//= new Vector3(1.5f, 1.5f, 1.5f);

        CircleCollider2D col = currentCharacterInstance.GetComponent<CircleCollider2D>();

        if (col != null)
        {
            col.enabled = false;
            col.enabled = true;
        }


    }
    public void NextCharcter()
    {
        Displayed_Character++;
        if (Displayed_Character >= characters.Count)
        {
            Displayed_Character = 0;
        }

        DisplayCharacters();
        Debug.Log($"Spawned character {Displayed_Character} with scale {currentCharacterInstance.transform.localScale}");

    }
    public void BackCharcter()
    {
        Displayed_Character--;
        if (Displayed_Character < 0)
        {
            Displayed_Character = characters.Count - 1;
        }
        DisplayCharacters();


    }

    public void SaveCharacter()
    {
        SelectedCharacterPrefab = characters[Displayed_Character].characterPrefab;

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


    public void changeSceneToOptionScreen()
    {
        SceneManager.LoadScene(optionScreenSceneName);
    }
}

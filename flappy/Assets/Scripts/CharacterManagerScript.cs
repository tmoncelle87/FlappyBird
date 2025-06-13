using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class CharacterManagerScript : MonoBehaviour
{
    public Transform spawnStartPoint; // Empty GameObject in scene
    public List<ChcratacterTestScript> characters = new List<ChcratacterTestScript>();
    public int Displayed_Character = 0;
    public GameObject currentCharacterInstance;
    void Start()
    {
        DisplayCharacters();
    }
    public void DisplayCharacters()
    {
        
        Vector3 spawnPos = spawnStartPoint.position;
        if (currentCharacterInstance != null)
        {
            Destroy(currentCharacterInstance);
        }

        
        currentCharacterInstance = Instantiate(characters[Displayed_Character].characterPrefab, spawnPos, Quaternion.identity);


    }
    public void NextCharcter()
    {
        Displayed_Character++;
        if (Displayed_Character >= characters.Count)
        {
            Displayed_Character = 0;
        }

        DisplayCharacters();

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

    public GameObject SaveCharacter()
    {

        return currentCharacterInstance;
    }
}

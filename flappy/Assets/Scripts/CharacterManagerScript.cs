using UnityEngine;
using UnityEngine.UI;

public class CharacterManagerScript : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;

    void Start()
    {
        if (characterDB == null)
        {
            Debug.LogError("CharacterDatabase is not assigned.");
            return;
        }

        // Load the selectedOption from PlayerPrefs
        if (PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = PlayerPrefs.GetInt("selectedOption");
        }

        UpdateCharacter();
    }

    public void NextOption()
    {
        selectedOption = (selectedOption + 1) % characterDB.CharacterCount;
        UpdateCharacter();
        SaveSelection();
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter();
        SaveSelection();
    }

    private void UpdateCharacter()
    {
        if (characterDB != null && artworkSprite != null)
        {
            CharacterScript selectedCharacter = characterDB.GetCharacter(selectedOption);
            if (selectedCharacter != null)
            {
                artworkSprite.sprite = selectedCharacter.characterSprite;
            }
            else
            {
                Debug.LogError("Invalid character index: " + selectedOption);
            }
        }
    }

    private void SaveSelection()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
        PlayerPrefs.Save();
    }
}
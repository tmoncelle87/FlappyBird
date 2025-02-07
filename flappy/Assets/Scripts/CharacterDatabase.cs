using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public CharacterScript[] characters;

    public int CharacterCount
    {
        get
        {
            return characters.Length;
        }
    }

    public CharacterScript GetCharacter(int index)
    {
        if (index >= 0 && index < characters.Length)
        {
            return characters[index];
        }
        else
        {
            Debug.LogError("Invalid character index: " + index);
            return null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform spawnPoint; // Assign in Inspector
    public GameObject defaultCharacterPrefab;
    void Start()
    {
        GameObject spawnedCharacter;

        if (CharacterManagerScript.SelectedCharacterPrefab != null)
        {
            spawnedCharacter = Instantiate(CharacterManagerScript.SelectedCharacterPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No character selected! Using default...");
            spawnedCharacter = Instantiate(defaultCharacterPrefab, spawnPoint.position, Quaternion.identity);
        }
        spawnedCharacter.SetActive(true);
        Rigidbody rb = spawnedCharacter.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.WakeUp();
            rb.sleepThreshold = 0f;  // optionally disable sleeping entirely
        }

        Rigidbody2D rb2d = spawnedCharacter.GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.WakeUp();
            rb2d.sleepMode = RigidbodySleepMode2D.NeverSleep;  // optionally disable sleeping entirely
        }
    }
}

using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource; // The AudioSource component used to play sounds.
    public AudioClip clickSound;    // The AudioClip to play for clicks. Set in the Inspector.
    private static SoundManager instance; // Singleton instance of the SoundManager.

    void Awake()
    {
        // Singleton pattern to ensure only one SoundManager exists.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist this GameObject across scene loads.
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate SoundManagers.
            return; // Exit to prevent further initialization of this duplicate.
        }

        // Get the AudioSource component or add one if it doesn't exist.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the clickSound to the AudioSource.
        audioSource.clip = clickSound;
    }

    // Static method to play the click sound. Can be called from any script.
    public static void PlayClick()
    {
        // Check if the SoundManager is properly set up before playing the sound.
        if (instance != null && instance.audioSource != null && instance.clickSound != null)
        {
            instance.audioSource.PlayOneShot(instance.clickSound); // Play the sound.
        }
        else
        {
            Debug.LogError("SoundManager not properly set up!"); // Log an error if setup is incorrect.
        }
    }
}
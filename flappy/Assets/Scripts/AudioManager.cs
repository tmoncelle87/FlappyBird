using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource backgroundMusic;

    private const string MUSIC_VOLUME_KEY = "MusicVolume";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;


        float savedVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 1f);
        SetMusicVolume(savedVolume);

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }

    public void SetMusicVolume(float volume)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = volume;
        }
    }

    public void SaveVolume()
    {
        if (backgroundMusic != null)
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, backgroundMusic.volume);
            PlayerPrefs.Save();
        }
    }

    // ... (Rest of your AudioManager code: PlaySound, StopMusic, PlayMusic)

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
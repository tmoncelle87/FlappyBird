// VolumeControl.cs (Complete and Corrected)
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider musicVolumeSlider;

    private void Start()
    {
        AudioManager audioManager = AudioManager.Instance;

        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found!");
            return;
        }

        if (musicVolumeSlider == null)
        {
            musicVolumeSlider = GameObject.FindGameObjectWithTag("MusicSlider").GetComponent<Slider>(); // Try to find with tag
        }

        if (musicVolumeSlider == null)
        {
            Debug.LogError("Music Volume Slider not found.  Assign it in the inspector or add the tag 'MusicSlider'.");
            return;
        }

        musicVolumeSlider.value = audioManager.backgroundMusic.volume;
        musicVolumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChanged);
    }

    private void OnVolumeSliderValueChanged(float volume)
    {
        AudioManager audioManager = AudioManager.Instance;

        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found!");
            return;
        }

        audioManager.SetMusicVolume(volume);
        audioManager.SaveVolume();
    }

    private void OnDestroy()
    {
        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.onValueChanged.RemoveListener(OnVolumeSliderValueChanged);
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogiceManage : MonoBehaviour
{
    public string sceneName; // Name of the scene to load. Set in the Inspector.

    void Start()
    {
        // Initialization (currently empty).
    }

    void Update()
    {
        // Per-frame updates (currently empty).
    }

    public void changeScene()
    {
        // Loads the specified scene. Called by UI buttons or other triggers.
        SceneManager.LoadScene(sceneName);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public static int playerScore = 0;
    public static int highScore = 0;
    public Text scoreText;

    public AudioClip flapSound; // AudioClip for the flap sound effect
    private AudioSource audioSource;

    void Start()
    {
        if (logic == null)
        {
            GameObject logicGO = GameObject.FindGameObjectWithTag("Logic");
            if (logicGO != null)
            {
                logic = logicGO.GetComponent<LogicScript>();
                if (logic == null)
                {
                    Debug.LogError("LogicScript component not found on the Logic GameObject.");
                }
            }
            else
            {
                Debug.LogError("No GameObject with the 'Logic' tag found.");
            }
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (flapSound != null)
        {
            audioSource.clip = flapSound;
            audioSource.volume = 0.4f; // Set volume to 60% here
        }
        else
        {
            Debug.LogError("Assign a flap sound AudioClip to BirdScript in the Inspector!");
        }

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;

            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
            else
            {
                if (audioSource == null)
                {
                    Debug.LogWarning("Audio Source not assigned in Bird Script.");
                }
                if (audioSource.clip == null)
                {
                    Debug.LogWarning("Audio Clip not assigned in Bird Script.");
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)
        {
            birdIsAlive = false;
            if (logic != null)
            {
                logic.gameOver();
            }

            SaveHighScore();
        }
    }

    public void UpdatePlayerScore(int points)
    {
        playerScore += points;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + playerScore.ToString();
        }
        if (playerScore > highScore)
        {
            highScore = playerScore;
            SaveHighScore();
        }
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void OnEnable()
    {
        LoadHighScore();
    }
}
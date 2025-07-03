using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public AudioClip flapSound;
    private AudioSource audioSource;
    public LogicScript logic;
    public BirdScript birdLogic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdLogic = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            //if (flapSound != null) 
            audioSource.PlayOneShot(flapSound);
            //if (logic != null) 
            logic.addScore(1);
            //if (birdLogic != null)
            birdLogic.UpdatePlayerScore(1);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.sleepThreshold = 0f;  // disables sleeping
            rb.WakeUp();             // wakes it immediately
        }
    }

    // Update is called once per frame
    void Update()
    {
        // You can leave this empty or remove it if not needed
    }
}

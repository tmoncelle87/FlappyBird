using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MountainJitterScript : MonoBehaviour
{

    public Sprite MountainImage;
    public Image imageUI;

    // Start is called before the first frame update
    void Start()
    {
        imageUI.sprite = MountainImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

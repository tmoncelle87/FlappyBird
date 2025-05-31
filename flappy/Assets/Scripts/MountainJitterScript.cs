using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MountainJitterScript : MonoBehaviour
{
    private RectTransform ObjectImage;


    public float speed;
    public float leftLimit;
    public float rightLimit;
    private bool movingRight;

    void Start()
    {
        ObjectImage = GetComponent<RectTransform>();
        Vector2 pos = ObjectImage.anchoredPosition;
        if (pos.x > rightLimit)
        {
            movingRight = false;
        }
        else if (pos.x < leftLimit)
        {
            movingRight = true;
        }
    }

    void Update()
    {
        Vector2 pos = ObjectImage.anchoredPosition;


            

        if (movingRight)
        {
            pos.x += speed * Time.deltaTime;
            if (pos.x >= rightLimit)
            {
                pos.x = rightLimit;
                movingRight = false;
            }
        }
        else
        {
            pos.x -= speed * Time.deltaTime;
            if (pos.x <= leftLimit)
            {
                pos.x = leftLimit;
                movingRight = true;
            }
        }

        ObjectImage.anchoredPosition = pos;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    private void Start()
    {
        // this was originally set to the y axis and not the x axis, so it was repeating vertically and not left to right
        startPos = transform.position;  
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; 
    }

    private void Update()
    {
        
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }

 
}



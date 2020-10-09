using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //handles the scrolling background, moving it down at a set rate. The background is the same image stacked over itself two times
        // so as it travels, when it reaches the exact moment the second image perfectly matches the starting position of the first image
        // reset both images so that they can "permanently" scroll.
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);

        if (transform.position.z < -107.0f) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -6.9f);
        }
    }
}

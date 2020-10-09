using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotates the ship in the select screen
        transform.Rotate(0, 0.1f, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    /*
     * This script exists to keep the shop menu active after leaving the scene, but an issue existed where many shop menus were being created.
     so we have to make sure never to destroy the original shop Menu but destroy the extras that are created.
     * 
     */
    void Start()
    {
        GameObject[] gObjs;
        gObjs = GameObject.FindGameObjectsWithTag("shopMenu");
        if (gObjs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

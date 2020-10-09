using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    public int cc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //responsible for destroying the empty parent gameObject, when all of it's children (and thus their scripted behaviors) are destroyed.
        cc = transform.childCount;
        if (transform.childCount == 0) 
        {
            Destroy(transform.gameObject); 
        }
    }

}

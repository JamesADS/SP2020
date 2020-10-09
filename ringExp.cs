using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringExp : MonoBehaviour
{
    public float damage = 25.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when the ring from the explosion collides with an enemy, grab the attached script and modify the health appropriately.
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "basic")
        {
            other.gameObject.GetComponent<basicWyrm>().health -= damage;
            //Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "BA")
        {



            other.gameObject.GetComponent<BAxeBehavior>().health -= damage;

            //Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "lazer")
        {



            other.gameObject.GetComponent<lazer>().health -= damage;

            //Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "magma")
        {



            other.gameObject.GetComponent<magma>().health -= damage;

            //Destroy(this.gameObject);
        }

    }
}

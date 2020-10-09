using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCol : MonoBehaviour
{
    

    public float damage = 10.0f;
    
    public Material hitMat;
    public Material normalMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**/
    /*
    void OnCollisionEnter()

    NAME

        void OnCollisionEnter()

    SYNOPSIS


    DESCRIPTION

        Whenever a collision occurs involving the gameObject this script is attached to, this function is automatically called.
        We can get the other game object we have come into contact with, and perform actions accordingly. In this case, when we collide we an enemy
        we look at the tag that is attached to the gameObject so we can access the correct script and remove the HP accordingly.

        This script is only for player bullets, as the enemy bullets have a different prefab.

    RETURNS

           nothing.

    AUTHOR

        James P Giordano

    DATE

        8/4/2020

    */
    /**/

    void OnCollisionEnter(Collision other)
    {
        //check the tag of the enemy, subtract HP from the acccording script. Then, destroy this object!
        if (other.gameObject.tag == "basic")
        {
            
           
            
           
            other.gameObject.GetComponent<basicWyrm>().health -= damage;
           
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "BA")
        {
                       

            other.gameObject.GetComponent<BAxeBehavior>().health -= damage;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "lazer")
        {


            other.gameObject.GetComponent<lazer>().health -= damage;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "magma")
        {


            other.gameObject.GetComponent<magma>().health -= damage;

            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "octoBoss")
        {


            other.gameObject.GetComponent<octoBoss>().health -= damage/2;

            Destroy(this.gameObject);
        }
    }

}

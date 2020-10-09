using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketCol : MonoBehaviour
{
    public float damage = 50.0f;
    public GameObject explosion;
    public GameObject ringEXP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "basic")
        {
            
            
            
            other.gameObject.GetComponent<basicWyrm>().health -= damage;

            rocketEX();
        }
        if (other.gameObject.tag == "BA")
        {



            other.gameObject.GetComponent<BAxeBehavior>().health -= damage;

            rocketEX();
        }
        if (other.gameObject.tag == "lazer")
        {



            other.gameObject.GetComponent<lazer>().health -= damage;

            rocketEX();
        }
        if (other.gameObject.tag == "magma")
        {



            other.gameObject.GetComponent<magma>().health -= damage;

            rocketEX();
        }
        if (other.gameObject.tag == "octoBoss")
        {



            other.gameObject.GetComponent<octoBoss>().health -= damage;

            rocketEX();
        }
    }

    /**/
    /*
    void rocketEX()

    NAME



    SYNOPSIS


    DESCRIPTION

        handles the explosion of the rocket by instantiating a particle explosion and an explosion ring at the moment the rocket is destroyed.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/20/2020

    */
    /**/

    void rocketEX()
    {
        
        GameObject exp;
        GameObject ringEX;
        exp = Instantiate(explosion, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
        ringEX = Instantiate(ringEXP, exp.transform.position, ringEXP.transform.rotation) as GameObject;
        Destroy(this.gameObject);
        Destroy(exp, 1.0f);
        Destroy(ringEX, 1.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().currHP -= 5.0f;
        }
    }
}

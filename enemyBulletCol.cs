using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletCol : MonoBehaviour
{
    public float damage = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("die", 4.0f);
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
        We can get the other game object we have come into contact with, and perform actions accordingly. In this case, when we collide we the player
        we look at the tag that is attached to the gameObject so we can access the correct script and remove the HP accordingly.

        This script is only for enemy bullets, which thanks to Unity's layering system have been set up to only be able to hit the player, but it is nice to check anyways.

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

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().currHP -= damage;
            Destroy(this.gameObject);
        }
    }

    void die()
    {
        Destroy(this.gameObject);
    }
}

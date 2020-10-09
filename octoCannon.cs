using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class octoCannon : MonoBehaviour
{
    public GameObject bullet;
    private float fireRate = 0.8f;
    private float myTime = 0;
    public GameObject bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //the cannons fire every 0.8 seconds, as mytime is added to, everytime is is over 0.8s then a shot is fired and the shoot function is Invoked.
        myTime += Time.deltaTime;
        if(myTime > fireRate)
        {
            Invoke("shoot", 0.0f);
            myTime = 0.0f;
        }
    }

    /**/
    /*
    void shoot()

    NAME



    SYNOPSIS


    DESCRIPTION

        Instantiate a bullet object to be spawned at a designated spot, append a rigidbody to handle physics, and add some force to it.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/15/2020

    */
    /**/

    void shoot()
    {
        GameObject tempBullet;
        tempBullet = Instantiate(bullet, bulletSpawner.transform.position, bullet.transform.rotation);

        Rigidbody tempRigidbody;
        tempRigidbody = tempBullet.GetComponent<Rigidbody>();

        tempRigidbody.AddForce(0, 0, -2150.0f);

        Destroy(tempBullet, 10.0f);
    }
}

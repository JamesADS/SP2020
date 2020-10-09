using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bulletEmitter;
    public GameObject bullet;
    public GameObject rocket;
    public GameObject specialShot;
    public GameObject altSpawner;
    public float bulletforce;
    public GameObject explosion;
    
    public float bulletlifeTime;
    public float rocketlifeTime;
    public float specialLifeTime;
    public float fireRate;
    private float nextFire = 0.5f;
    private float myTime = 0.0f;
    private float myAltTime = 0.0f;
    private float mySpecialTime = 15.0f;
    public float altCD = 6.5f;
    public float specialCD = 15.0f;
    public bool press;
    public float trigger;
    public float altTrigger;
    public bool SpecPress;
    public RectTransform ALTBar;
    public RectTransform SpecBar;
    private float altbarx;
    private float specbarx;
    public GameObject ringEXP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //be ready for and receive player inputs.
        myTime = myTime + Time.deltaTime;
        myAltTime = myAltTime + Time.deltaTime;
        mySpecialTime += Time.deltaTime;
        press = Input.GetMouseButton(0);
        trigger = Input.GetAxis("Fire1");
        altTrigger = Input.GetAxis("Fire2");
        SpecPress = Input.GetButtonDown("Fire3");

        //based on player inputs and cooldowns, ensure that the proper functions are called.
        if( (press || (trigger != 0)) && myTime > nextFire)
        {
            nextFire = myTime + fireRate;
            shoot();
            nextFire = nextFire - myTime;
            myTime = 0.0f;
        }
        if( altTrigger != 0 && (myAltTime > altCD))
        {
            myAltTime = 0.0f;
            shootAlt();
        }
        if (SpecPress && (mySpecialTime > specialCD))
        {
            mySpecialTime = 0.0f;
            shootSpec();
        }

        //modify the bars representing the cooldowns of the alternate fire ability and the special ability, if necessary
        altbarx = (myAltTime / altCD) * 200;
        if (altbarx > 200)
        {
            altbarx = 200;
        }
        specbarx = (mySpecialTime / specialCD) * 200;
        if(specbarx > 200)
        {
            specbarx = 200;
        }

        ALTBar.sizeDelta = new Vector2(altbarx, ALTBar.sizeDelta.y);
        SpecBar.sizeDelta = new Vector2(specbarx, SpecBar.sizeDelta.y);




    }

    void FixedUpdate()
    {
        
    }
    /**/
    /*
    void shoot()

    NAME



    SYNOPSIS


    DESCRIPTION


        Instantiate a temporary game object - essentially a clone, attach a rigidbody (for physics handling) and add a force vector to the attached rigidbody.
        this will effectively "fire" a bullet. At the end of the function we make sure the bullet will be destroyed.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        8/27/2020

    */
   
    /**/

    void shoot()
    {
        
            GameObject tempBullet;
            tempBullet = Instantiate(bullet, bulletEmitter.transform.position, bullet.transform.rotation) as GameObject;
            

            Rigidbody tempRigidbody;
            tempRigidbody = tempBullet.GetComponent<Rigidbody>();

            tempRigidbody.AddForce(0, 0, bulletforce);

            Destroy(tempBullet, bulletlifeTime);
        
        
    }
    /**/
    /*
    void shootAlt()

    NAME



    SYNOPSIS


    DESCRIPTION

        Instantiate a temporary game object - essentially a clone, attach a rigidbody (for physics handling) and add a force vector to the attached rigidbody.
        this will effectively "fire" a rocket. At the end of the function we make sure the rocket is destroyed, and start a coroutine the handle the rocket explosion.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        8/28/2020

    */
    /**/

    void shootAlt()
    {
        GameObject tempRocket;
        tempRocket = Instantiate(rocket, altSpawner.transform.position, rocket.transform.rotation) as GameObject;

        Rigidbody tempRigidbody;
        tempRigidbody = tempRocket.GetComponent<Rigidbody>();

        tempRigidbody.AddForce(0, 0, 5000);
        Destroy(tempRigidbody, 3.0f);
        StartCoroutine(rocketEX(tempRocket, rocketlifeTime));
        Destroy(tempRocket, rocketlifeTime);
    }

    /**/
    /*
    IEnumerator rocketEX()

    NAME

        IEnumerator rocketEX(GameObject tempRocket, float toWait)

    SYNOPSIS

        temprocket -> the gameObject used to determine where the explosion will spawn
        toWait -> the number of seconds to wait before creating this explosion.

    DESCRIPTION

        sleep until just before we need to create the explosion, and then instantiate an explosion and the explosion ring. 

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        8/29/2020

    */
    /**/

    IEnumerator rocketEX(GameObject tempRocket, float toWait)
    {
        yield return new WaitForSeconds(toWait - 0.05f);
        GameObject exp;
        GameObject ringEX;
        exp = Instantiate(explosion, tempRocket.transform.position, rocket.transform.rotation) as GameObject;
        ringEX = Instantiate(ringEXP, exp.transform.position, ringEXP.transform.rotation) as GameObject;
        Destroy(exp, 1.0f);
        Destroy(ringEX, 1.0f);
    }

    /**/
    /*
    void shootSpec()

    NAME



    SYNOPSIS


    DESCRIPTION

        Instantiate a temporary gameObject to form our special attack, start a coroutine to call the function to handle the physics, because we need to wait for the animation to finish.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/2/2020

    */
    /**/

    void shootSpec()
    {
        GameObject tempSpec;
        tempSpec = Instantiate(specialShot, altSpawner.transform.position, specialShot.transform.rotation) as GameObject;
        StartCoroutine(pushSpec(tempSpec, 2.0f));

    }

    /**/
    /*
    IEnumerator pushSpec(GameObject tempSpec, float toWait)

    NAME



    SYNOPSIS

        GameObject tempSpec - > the gameobject representing the attack that needs physics applied.
        toWait - > the amount of time to wait before we start applying physics.

    DESCRIPTION

        while the animation is playing, sleep. Wake up, apply a rigidbody and addforce to the rigidbody. Destroy the temporary gameobject eventually.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/2/2020

    */
    /**/

    IEnumerator pushSpec(GameObject tempSpec, float toWait)
    {
        yield return new WaitForSeconds(toWait);
        Rigidbody tempRB;
        tempRB = tempSpec.GetComponent<Rigidbody>();

        tempRB.AddForce(0, 0, 3500);
        Destroy(tempSpec, rocketlifeTime);
    }
}

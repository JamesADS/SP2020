using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public float health = 100.0f;
    public GameObject laserShot;
    public RectTransform healthbar;
    public GameObject lazerEmitter;
    Animator con;
    public ParticleSystem ps;
    public GameObject[] drops = new GameObject[5];
    public enum mapped { tin, copper, coal, gold, wyrm }

    // Start is called before the first frame update
    void Start()
    {
        //this enemy has an attached particle system, but we only want it to play as a part of its attack animation. 
        ps.Pause();
        Invoke("charge", Random.Range(2.0f, 4.0f));
        con = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1.0f)
        {
            die();
        }
        healthbar.sizeDelta = new Vector2(health / 2, healthbar.sizeDelta.y);
    }
    /**/
    /*
    void charge()

    NAME

        charge

    SYNOPSIS


    DESCRIPTION

        acts as a first step for animation purposes. Turns the particle system of the attached gameObject on and waits to fire, simulating a "charge".

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        8/4/2020

    */
    /**/
    void charge()
    {
        ps.Play();
        Invoke("fire", 3.0f);
        
    }

    /**/
    /*
    void fire()

    NAME

        fire

    SYNOPSIS


    DESCRIPTION

        clears and pauses the particle system, and instantiates a cylindrical gameObject that expands rapidly in one direction, and moves slowly in that same direction.
        when viewed from a birds eye creates a sort of lazer like effect. Within the scope of this function we also set a destruction time for the new object, and call our charge function again.

    RETURNS



    AUTHOR



    DATE



    */
    /**/

    void fire()
    {
        ps.Clear();
        ps.Pause();
        GameObject tempLazer;
        tempLazer = Instantiate(laserShot, lazerEmitter.transform.position, laserShot.transform.rotation) as GameObject;
        //Rigidbody tempRigidbody;
        //tempRigidbody = tempLazer.GetComponent<Rigidbody>();
        //tempRigidbody.AddForce(0, 0, -100.0f, ForceMode.VelocityChange);

        Destroy(tempLazer, 4.0f);

        Invoke("charge", Random.Range(2.0f, 4.0f));
    }

    /**/
    /*
    void die()

    NAME

        die()

    SYNOPSIS
            
            

    DESCRIPTION

        Responsible for destroying the gameobject attached to this script when it runs out of health. Also included before destroying the gameobject
        is the random generation of loot to be dropped. An integer from 1-100 inclusive is rolled and sets a mapped value to be tested against a switch case.
        This then selects from an array the correct resource and to display.

        for example: (random roll) -> 67 -> maps to "coal" from enum -> case "coal" in the switch -> accesses the array of possible resource drops at dropArray[2]
        this allows for modularity at any stage of the generation, The chance of each resource, OR what the resource is.
        Instantiates an image of the drop as a pop-up on screen. Then finishes destroying the dying gameObject we are attached to.

    RETURNS

        nothing.

    AUTHOR

        James P. Giordano

    DATE

        8/4/2020

    */
    /**/

    void die()
    {
        GameObject tempImage;
        int roll = UnityEngine.Random.Range(1, 101);
        mapped mappedStr;
        if (roll < 30)
        {
            mappedStr = (mapped)0;
        }
        else if (roll >= 30 && roll < 60)
        {
            mappedStr = (mapped)1;
        }
        else if (roll >= 60 && roll <= 90)
        {
            mappedStr = (mapped)2;
        }
        else if (roll <= 98)
        {
            mappedStr = (mapped)3;
        }
        else
        {
            mappedStr = (mapped)4;
        }


        switch (mappedStr)
        {
            case ((mapped)0):
                tempImage = Instantiate(drops[0], this.gameObject.transform.position, drops[0].transform.rotation) as GameObject;
                break;
            case ((mapped)1):
                tempImage = Instantiate(drops[1], this.gameObject.transform.position, drops[1].transform.rotation) as GameObject;
                break;
            case ((mapped)2):
                tempImage = Instantiate(drops[2], this.gameObject.transform.position, drops[2].transform.rotation) as GameObject;
                break;
            case ((mapped)3):
                tempImage = Instantiate(drops[3], this.gameObject.transform.position, drops[3].transform.rotation) as GameObject;
                break;
            case ((mapped)4):
                tempImage = Instantiate(drops[4], this.gameObject.transform.position, drops[4].transform.rotation) as GameObject;
                break;

        }
        Destroy(this.gameObject);
    }

}

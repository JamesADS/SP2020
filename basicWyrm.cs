using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class basicWyrm : MonoBehaviour
{
    public float health = 100.0f;
    public RectTransform healthbar;
    public GameObject bulletRed;
    public float bulletforce;
    public float bulletlifeTime;
    public GameObject basicbulletEmitter;
    public GameObject[] drops = new GameObject[5];
    public enum mapped { tin, copper, coal, gold, wyrm}
    

    // Start is called before the first frame update
    void Start()
    {
        //Have the enemies shoot at a bounded random interval.
        Invoke("shoot", UnityEngine.Random.Range(0.8f, 1.5f));
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
    void shoot()

    NAME

        basicWyrm::shoot() - handles shooting for the basic wyrm enemy.

    SYNOPSIS
        
        void shoot()

    DESCRIPTION

        Instantiate a temporary game object - essentially a clone, attach a rigidbody (for physics handling) and add a force vector to the attached rigidbody.
        this will effectively "fire" a bullet. At the end of the function we make sure the bullet will be destroyed one way or another, and we call the function again
        using the same bounded random interval. This gets around using any kind of boolean handling in our update loop.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        8/3/2020

    */
    /**/
    void shoot()
    {
        GameObject tempBullet;
        tempBullet = Instantiate(bulletRed, basicbulletEmitter.transform.position, bulletRed.transform.rotation) as GameObject;


        Rigidbody tempRigidbody;
        tempRigidbody = tempBullet.GetComponent<Rigidbody>();

        tempRigidbody.AddForce(0, 0, -bulletforce);

        Destroy(tempBullet, bulletlifeTime);
        Invoke("shoot", UnityEngine.Random.Range(0.8f, 1.5f));
    }
    /* void shoot()*/

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

        8/3/2020

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

    //we dont want to have lots of empty clone parent objects floating around, so this just ensures that they are leaving too.
    private void OnDestroy()
    {
        if (transform.parent != null) // if object has a parent
        {
            if (transform.childCount <= 1) // if this object is the last child
            {
                Destroy(transform.parent.gameObject, 0.1f); // destroy parent a few frames later
            }
        }
    }
}

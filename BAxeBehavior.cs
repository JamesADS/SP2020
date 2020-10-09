using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAxeBehavior : MonoBehaviour
{

    public float health = 200.0f;
    bool right = true;
    bool movement = true;
    Vector2 screenSize;
    Animator con;
    public float damage = 12.0f;
    public RectTransform healthbar;
    public GameObject[] drops = new GameObject[5];
    public enum mapped { tin, copper, coal, gold, wyrm }

    // Start is called before the first frame update
    void Start()
    {
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        con = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //refresh the size of the health bar in case it has changed.
        healthbar.sizeDelta = new Vector2(health / 2, healthbar.sizeDelta.y);
        
        if (health < 1.0f)
        {
            die();
        }

        //while it would be nice to not have to worry about this, we need to not be updating our position while animating. So there needs to be times where we turn this
        //automatic scriped movement off. This is done withe the boolean named movement.
        if (movement)
        {
            //are we moving to the right or the left?
            if (right)
            {
                transform.position = new Vector3(transform.position.x + 0.15f, 0, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 0.15f, 0, transform.position.z);
            }
        }

        //if we hit the edge of the screen (left side or right side) we need to play the appropriate animation for turning around, and then resume our normal movement pattern after the duration of the animation.
        //the 'right' boolean lets us know if we are going right or not.
        if (transform.position.x > screenSize.x)
        {
            right = false;
            con.SetBool("rightside", true);
            movement = false;
            Invoke("turnOffRight", 1.65f);
        }
        else if (transform.position.x < -screenSize.x)
        {
            right = true;
            movement = false;
            con.SetBool("leftside", true);
            Invoke("turnOffLeft", 1.65f);
        }

        //once we hit the bottom of the screen, reset the z coordinate to a random bounded interval.
        if(transform.position.z < -screenSize.y)
        {
            transform.position = new Vector3(transform.position.x, 0, Random.Range(20.0f, 35.0f));
        }
    }

    /**/
    /*
    void turnOffRight()

    NAME

        turnOffRight

    SYNOPSIS


    DESCRIPTION

        sets the 'rightside' variable to false, which is a boolean inside the animator controller that helps control the state of the animations.
        by setting a boolean here we can determine that it is time to change an animation state. Also lets us resume our normal movement pattern in
        'Update()'

    RETURNS

        nothing.

    AUTHOR

        James P. Giordano

    DATE

        8/4/2020

    */
    /**/

    void turnOffRight()
    {
        con.SetBool("rightside", false);
        movement = true;
        //transform.position = new Vector3(transform.position.x, 0, transform.position.z - .05f);
        //transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
    }

    /**/
    /*
    void turnOffLeft()

    NAME

        void turnOffLeft()

    SYNOPSIS


    DESCRIPTION

        sets the 'leftside' variable to false, which is a boolean inside the animator controller that helps control the state of the animations.
        by setting a boolean here we can determine that it is time to change an animation state. Also lets us resume our normal movement pattern in
        'Update()

    RETURNS

        nothing.

    AUTHOR

        James P Giordano

    DATE

        8/4/2020    

    */
    /**/

    void turnOffLeft()
    {
        con.SetBool("leftside", false);
        movement = true;
    }
    /**/
    /*
    void OnCollisionEnter()

    NAME

        void OnCollisionEnter()

    SYNOPSIS


    DESCRIPTION

        Whenever a collision occurs involving the gameObject this script is attached to, this function is automatically called.
        We can get the other game object we have come into contact with, and perform actions accordingly. In this case, when we collide with the player
        we want to ensure that they lose health, so we can access the script attached to the Player gameObject and get the float holding the current HP.

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
        }
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
}

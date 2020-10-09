using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class octoBoss : MonoBehaviour
{

    public float health = 1000.0f;
    public float maxHealth = 1000.0f;
    public RectTransform healthbar;
    public Text hptext;
    Animator con;
    
    private bool attacking = false;
    private int teleports = 0;
    private float attackTime = 6.0f;
    private float myTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //attach the animator to a variable. This will be used to influence the animation state from this script, at the times that we want.
        con = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if we are already attacking, don't roll for an attack.
        //there is a base time between attacks, make sure we are above this.
        
        if (!attacking && myTime > attackTime) 
        {
            //if both of these conditions are ok, roll for a random attack. Nice to write like this more attacks can be added without changing the general idea behind the code.
            int roll = Random.Range(1, 3);
            switch (roll)
            {
                case 1:
                    //The Boss throws the sawblade like object at the player.
                    //invoke spinnerAttack() after 2.5 seconds, change the animation state, and check off that we are attacking so we don't enter this loop again too soon.
              
                    Invoke("spinnerAttack", 2.5f);
                    con.SetBool("saw1", true);
                    con.SetBool("idle", false);
                    attacking = true;
                    //reset the attack time.
                    myTime = 0;
                    break;
                case 2:
                    this.gameObject.transform.position = new Vector3(0.0f, this.gameObject.transform.position.y, 0.0f);
                    Invoke("stabAttack", 2.5f);
                    con.SetBool("stab", true);
                    attacking = true;
                    myTime = 0.0f;
                    break;
            }
            
        }
        //continue incrementing time while we wait for our next attack.
        myTime += Time.deltaTime;
        //continue updating the healthbar
        healthbar.sizeDelta = new Vector2((health / maxHealth) * 200, healthbar.sizeDelta.y);
        hptext.text = "BOSS:" + health.ToString() + "/1000";
        if (health <= 0)
        {
            Invoke("die", 0.0f);
        }
    }
    /**/
    /*
    void spinnerAttack()

    NAME



    SYNOPSIS


    DESCRIPTION

        change the animation state and invoke the next portion of the attack "teleport". We Invoke after 1.2 seconds to give enough time for the animations to play.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/14/2020

    */
    /**/
    void spinnerAttack()
    {
        
        con.SetBool("saw1", false);
        con.SetBool("saw2", true);
        Invoke("teleport", 1.2f);

    }

    /**/
    /*
    void teleport()

    NAME



    SYNOPSIS


    DESCRIPTION

        the spin attack is comprised of two teleports and two swipes with the saw. The if and else blocks handle how many teleports we've taken. If we still have teleports left,
        modify the animation state appropriately, teleport to a random (bounded) location and initiate another spinner attack.

        if we are out of teleports, change the animation state back to the idle animation, reset our teleport counter, and set the attacking boolean to allow  us to roll randomly for attacks again.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/12/2020

    */
    /**/

    void teleport()
    {
        teleports += 1;
        if (teleports < 3)
        {
            
            con.SetBool("saw1", true);
            con.SetBool("saw2", false);
            this.gameObject.transform.position = new Vector3(Random.Range(-90.0f, 90.0f), this.gameObject.transform.position.y, Random.Range(10.0f, 30.0f));
            Invoke("spinnerAttack", 1.1f);
        }
        else
        {
            con.SetBool("saw1", false);
            con.SetBool("saw2", false);
            con.SetBool("idle", true);
            teleports = 0;
            attacking = false;
        }
    }

    void stabAttack()
    {
        attacking = false;
        con.SetBool("stab", false);
    }

    void die()
    {
        
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waves : MonoBehaviour
{
    public int wave = 1;
    public GameObject basicSpawner;
    public GameObject BaxeSpawner;
    
    private float spawnfreq = 4.0f;
    public GameObject basicEnemy;
    public GameObject BaxeEnemy;
    public GameObject lazerEnemy;
    public GameObject magmaEnemy;
    public GameObject octoBoss;
    private float spawnTime = 0.0f;
    public int points;
    public Image waveImg;
    public Text tempText;
    public bool unlocked = false;
    public bool deciding = false;
    public GameObject[] relics = new GameObject[3];
    public GameObject relicCanvas;
    

    // Start is called before the first frame update
    void Start()
    {
        setNum(1);
        sendWave(1);
    }

    // Update is called once per frame
    void Update()
    {
        //make sure we aren't spawning enemies too fast.
        spawnTime = spawnTime + Time.deltaTime;

        //once we have reached the spawn frequency timer, and we still have enemy points to allocate, we can spawn an enemy.
        if(spawnTime > spawnfreq && points > 0)
        {
            //reset the spawn time.
            spawnTime = 0.0f;
            //decide what kind of enemy will spawn with a random number.
            int enemyTag = Random.Range(1, 5);
            StartCoroutine(spawnBasic(enemyTag, 1.0f));
        }

        //if we are out of enemy points to allocate, the next wave of enemies may spawn.
        if (points <= 0 && !enemiesAlive() && !unlocked)
        {
            wave += 1;
            setNum(wave);
            sendWave(wave);
        }

        //unlocked is a boolean that tells us the Invoke relicChoice after defeating a boss. deciding is a boolean that doesn't let relicChoice get called hundreds of times per second 
        //as it is in the update loop.
        if (unlocked == true && !deciding && !enemiesAlive())
        {
            deciding = true;
            Invoke("relicChoice", 0.0f);
        }
    }

    /**/
    /*
    void sendWave(int waveNum)

    NAME



    SYNOPSIS

        waveNum - > the number of the wave to send. Certain numbers will correspond with in game actions.

    DESCRIPTION

        Allocate points to the wave will will be used to spawn enemies. if it is wave 5 we need to spawn a boss and nothing else. Unlock the relic choices when they will become applicable.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/21/2020

    */
    /**/

    void sendWave(int waveNum)
    {
        //points = 50;
        points += waveNum * 10;
        
        
        

        if (waveNum == 5)
        {
            points = 0;
            GameObject tempEnemy;
            tempEnemy = Instantiate(octoBoss, basicSpawner.transform.position, octoBoss.transform.rotation) as GameObject;
            tempEnemy.transform.position = new Vector3(0, 0, 30.0f);
            unlocked = true;







        }
        }


    /**/
    /*
    IEnumerator spawnBasic()

    NAME



    SYNOPSIS

        int enemyValue -> a random number sent that determines the enemy to be spawned.
        float toWait -> we don't want to spawn all the enemies at once, so we wait this long every time before sending a new enemy.

    DESCRIPTION

        wait for a set amount of time, and instantiate an enemy based on the enemy ID number provided to the function.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/16/2020

    */
    /**/
    IEnumerator spawnBasic(int enemyValue, float toWait)
    {
        yield return new WaitForSeconds(toWait);
        GameObject tempEnemy;

        //determine the type of enemy to spawn based on the random number rolled
        switch (enemyValue) 
        {
            //rolling a 1 spawns a "basicWyrm"
            case 1:
                tempEnemy = Instantiate(basicEnemy, basicSpawner.transform.position, basicEnemy.transform.rotation) as GameObject;

                tempEnemy.transform.position = new Vector3(Random.Range(-90.0f, 90f), 0, 45.0f);
                /*
                Rigidbody tempRigidbody;

                tempRigidbody = tempEnemy.AddComponent<Rigidbody>();
                tempEnemy.GetComponent<Rigidbody>().useGravity = false;
                tempRigidbody.AddForce(0, 0, -875);



                Destroy(tempRigidbody, 2.0f);
                */
                points -= 2;
                break;

            //rolling a 2 spawns a "BA wyrm"
            case 2:
                tempEnemy = Instantiate(BaxeEnemy, BaxeSpawner.transform.position, BaxeEnemy.transform.rotation) as GameObject;

                tempEnemy.transform.position = new Vector3(-90.0f, 0, Random.Range(10.0f, 20.0f));
                points -= 2;
                break;

            //rolling a 3 spawns a "lazer wyrm"
            case 3:
                tempEnemy = Instantiate(lazerEnemy, BaxeSpawner.transform.position, lazerEnemy.transform.rotation) as GameObject;

                tempEnemy.transform.position = new Vector3(Random.Range(-90.0f, 90.0f), 0, 30.0f);
                points -= 2;
                break;
            //rolling a 4 spawns a "magma wyrm"
            case 4:
                tempEnemy = Instantiate(magmaEnemy, BaxeSpawner.transform.position, magmaEnemy.transform.rotation) as GameObject;

                tempEnemy.transform.position = new Vector3(Random.Range(-90.0f, 90.0f), 0, 30.0f);
                points -= 3;
                break;
        }
       
        
    }

    /**/
    /*
    void setNum(in waveNum)

    NAME



    SYNOPSIS
        int waveNum - > the number wave that it is, we will be displaying this.

    DESCRIPTION

        set the text that will alert the player what wave they are on. Invoke the fadeIn function to show the image to the player.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/24/2020

    */
    /**/
    void setNum(int waveNum)
    {
        tempText.text = "- Wave " + waveNum.ToString() + " -";
        Invoke("fadeIn", 0.01f);
    }

    /**/
    /*
    void fadeIn()

    NAME



    SYNOPSIS


    DESCRIPTION

        fade in the color of the text and the border image that shows the player the wave number. This function continually invokes itself so that there is a staggering in the speed of the fade in.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/24/2020

    */
    /**/

    void fadeIn()
    {

        if ((tempText.color.a < 1.0f) && (waveImg.color.a < 1.0f))
        {
            Color current = tempText.color;
            current.a += 0.1f;
            tempText.color = current;
            current = waveImg.color;
            current.a += 0.1f;
            waveImg.color = current;

            Invoke("fadeIn", 0.1f);
        }
        else
        {
            Invoke("fadeOut", 1.0f);
        }
        
        

    }

    /**/
    /*
    void fadeOut()

    NAME



    SYNOPSIS


    DESCRIPTION

        fade out the color of the text and the border image that shows the player the wave number. This function continually invokes itself so that there is a staggering in the speed of the fade out.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/24/2020

    */
    /**/
    void fadeOut()
    {
        if ((tempText.color.a > 0.0f) && (waveImg.color.a > 0.0f))
        {
            Color current = tempText.color;
            current.a -= 0.1f;
            tempText.color = current;
            current = waveImg.color;
            current.a -= 0.1f;
            waveImg.color = current;

            Invoke("fadeOut", 0.1f);
        }
    }

    /**/
    /*
    bool enemiesAlive()

    NAME

        bool enemiesAlive()

    SYNOPSIS


    DESCRIPTION

        search for all of the possible enemy tags. If at any point an object exists with any tag that an enemy could have, this function returns true. returns false otherwise.

    RETURNS

        

    AUTHOR

        James P Giordano

    DATE

        9/24/2020

    */
    /**/

    bool enemiesAlive()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("magma");
        if (gos.Length > 0)
            {
                return true;
            }
        gos = GameObject.FindGameObjectsWithTag("BA");
        if (gos.Length > 0)
        {
            return true;
        }
        gos = GameObject.FindGameObjectsWithTag("basic");
        if (gos.Length > 0)
        {
            return true;
        }
        gos = GameObject.FindGameObjectsWithTag("lazer");
        if (gos.Length > 0)
        {
            return true;
        }
        gos = GameObject.FindGameObjectsWithTag("octoBoss");
        if (gos.Length > 0)
        {
            return true;
        }
        return false;

    }

    /**/
    /*
    void relicChoice()

    NAME



    SYNOPSIS


    DESCRIPTION

        Instantiate the relics that will make up slots 1, 2 and 3 in the selection. Not currently modular but could be made as such with the following steps:

        attach a GameObject[] array to this script, populate it with the GameObjects that will fill the choices.
        randomly generate i using Random.Range(1, n+1); n is the number of possible rewards.
        Instatiate three gameobjects, with the parameter being relics[i], relics([i+1]% n), and relics([i+2] % n).
        This will three consecutive choices from the array and will allow wrapping. Not the objectively best choice, but a quick and easy pseudo-random fix
        without contiguous memory management.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/24/2020

    */
    /**/

    void relicChoice()
    {
        relicCanvas.SetActive(true);
        int i = 0;
        var tempImage = Instantiate(relics[i]) as GameObject;
        tempImage.transform.SetParent(relicCanvas.transform, false);
        tempImage.transform.position = new Vector3(-50.0f, 0, 0);

        tempImage = Instantiate(relics[i+1]) as GameObject;
        tempImage.transform.SetParent(relicCanvas.transform, false);
        tempImage.transform.position = new Vector3(0, 0, 0);

        tempImage = Instantiate(relics[i + 2]) as GameObject;
        tempImage.transform.SetParent(relicCanvas.transform, false);
        tempImage.transform.position = new Vector3(50.0f, 0, 0);

    }
}

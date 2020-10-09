using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public float speed;
    private Rigidbody rb;
    public Vector3 movement;
    private Vector2 inputs;
    private float lastX;
    private float lastY;
    private bool first;
    public float shipWidth;
    public float shipLength;
    public RectTransform HPBar;
    public Text HPText;
    public GameObject deathCanvas;
    

    Vector2 screenSizeX;
    Vector2 screenSizeZ;
    public float MaxHP = 100.0f;
    public float currHP = 100.0f;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        first = true;
        lastX = 0.0f;
        lastY = 0.0f;
       // shipWidth = transform.localScale.x / 2;
       // shipWidth = transform.localScale.z / 2;
        screenSizeX = new Vector2(Camera.main.aspect * Camera.main.orthographicSize + shipWidth, Camera.main.orthographicSize);
        screenSizeZ = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize + shipLength);

    }

    // Update is called once per frame
    void Update()
    {
        //handle the player inputs on the displayed frames of the game. 
        inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //float hAxis = Input.GetAxis("Horizontal");
        //float vAxis = Input.GetAxis("Vertical");

        if (currHP > MaxHP)
        {
            currHP = MaxHP;
        }
        else if(currHP <= 0)
        {
            die();
        }
        //make sure the HP bar has the correct length.
        HPBar.sizeDelta = new Vector2(currHP * 2, HPBar.sizeDelta.y);
        HPText.text = currHP.ToString() + " / " + MaxHP.ToString();
    }

    
    void FixedUpdate()
    {

        float hAxis = inputs[0];
        float vAxis = inputs[1];
        //Handle the physics portion of the movement inside FixedUpdate, apply speed and rotation in the direction of our movement.
        movement = new Vector3(hAxis, 0, vAxis) * speed;
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(movement[0],0,0) * 1.2f);
        rb.MoveRotation(rb.rotation * deltaRotation);
        rb.MovePosition(transform.position + movement);

        //the following if and else if blocks prevent us from leaving the screen region.
        if(transform.position.x < -screenSizeX.x)
        {
            transform.position = new Vector3(-screenSizeX.x, 0, transform.position.z);
        }

        else if(transform.position.x > screenSizeX.x)
        {
            transform.position = new Vector3(screenSizeX.x, 0 , transform.position.z);
        }

        if (transform.position.z < -screenSizeZ.y)
        {
            transform.position = new Vector3(transform.position.x, 0, -screenSizeZ.y);
        }

        else if (transform.position.z > screenSizeZ.y)
        {
            transform.position = new Vector3(transform.position.x, 0, screenSizeZ.y);
        }


        //reset our rotation slightly, this was intentionally added to give a more "hovership" effect but ended up creating more headaches than was worth.
        //need to work on this portion specifically 
        if (!first && movement[0] != 0)
        {
            
            //the ship isn't stopped, needs to correct
            if (movement[0] != 0 && movement[0] > lastX)
            {
                rb.MoveRotation(rb.rotation * Quaternion.Euler(10,0,0));
            }
            if (movement[0] != 0 && movement[0] < lastX)
            {
                rb.MoveRotation(rb.rotation * Quaternion.Euler(-10, 0, 0));
            }
            

            
            




        }
        else
        {
            
            first = false;
        }
        lastX = movement[0];
        lastY = movement[2];
        
        
        



        

    }

    void die()
    {
        deathCanvas.SetActive(true);
        Destroy(this.gameObject);

    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "BA")
        {
            currHP -= other.gameObject.GetComponent<BAxeBehavior>().damage;
        }
    }
}

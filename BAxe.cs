using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA : MonoBehaviour
{
    public float health = 100.0f;
    bool right = true;
    Vector2 screenSize;
    Animator con;
    public float damage = 12.0f;
   

// Start is called before the first frame update
void Start()
    {
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        con = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        con.SetBool("rightside", false);
        con.SetBool("leftside", false);
        if (health < 1.0f)
        {
            die();
        }

        if (right)
        {
            transform.position = new Vector3(transform.position.x + 0.2f, 0, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - 0.2f, 0, transform.position.z);
        }

        if (transform.position.x > screenSize.x)
        {
            right = false;
            con.SetBool("rightside", true);
        }
        else if(transform.position.x < -screenSize.x)
        {
            right = true;
            con.SetBool("leftside", true);
        }

    }

    void die()
    {
        Destroy(this.gameObject);
    }
}

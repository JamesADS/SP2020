using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specCol : MonoBehaviour
{

    public float damage = 20.0f;
    public Rigidbody rb;
    public Vector3 LastV = new Vector3();
    private float myTime;
    // Start is called before the first frame update
    void Start()
    {
        rb.detectCollisions = true;
    }

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;
        if (myTime > 2.0f)
        {
            transform.position += new Vector3(0, 0, .1f);
        }
    }

    

    void OnTriggerEnter(Collider other)
    {
        //rb.velocity = new Vector3(0,0,70.0f);
        if (other.gameObject.tag == "basic")
        {



            other.gameObject.GetComponent<basicWyrm>().health /= 2;

            
        }
        if (other.gameObject.tag == "BA")
        {



            other.gameObject.GetComponent<BAxeBehavior>().health /= 2;

            
        }
        if (other.gameObject.tag == "lazer")
        {



            other.gameObject.GetComponent<lazer>().health /= 2;

           
        }
        if (other.gameObject.tag == "magma")
        {



            other.gameObject.GetComponent<magma>().health /= 2;

            
        }
        if (other.gameObject.tag == "octoBoss")
        {


            other.gameObject.GetComponent<octoBoss>().health -= 30.0f;

            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "basic")
        {



            other.gameObject.GetComponent<basicWyrm>().health -= 0.6f;


        }
        if (other.gameObject.tag == "BA")
        {



            other.gameObject.GetComponent<BAxeBehavior>().health -= 0.6f;


        }
        if (other.gameObject.tag == "lazer")
        {



            other.gameObject.GetComponent<lazer>().health -= 0.6f;


        }
        if (other.gameObject.tag == "magma")
        {



            other.gameObject.GetComponent<magma>().health -= 0.6f;


        }
    }
}

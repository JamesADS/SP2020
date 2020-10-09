using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magmaCol : MonoBehaviour
{
   

    public float damage = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        //if we don't hit the player we still need to worry about cleaning up the object.
        Invoke("die", 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //a transform of position called every update creates the bullet like projectile behavior.
        transform.position += new Vector3(0, 0, -0.2f);
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().currHP -= damage;
            Destroy(this.gameObject);
        }
    }

    void die()
    {
        Destroy(this.gameObject);
    }
}

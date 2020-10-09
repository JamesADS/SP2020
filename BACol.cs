using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BACol : MonoBehaviour
{
    public float damage = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Collided");
        //Thank to Unity's layering system, we can be almost certain that we have collided with the player, but it's nice to double check that we have.
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().currHP -= damage;
        }
    }
}

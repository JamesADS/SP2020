using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerCol : MonoBehaviour
{
    public float damage = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0, 0.15f, 0);
        transform.position += new Vector3(0, 0, -0.3f);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {




            other.gameObject.GetComponent<Player>().currHP -= damage;
            

            
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {




            other.gameObject.GetComponent<Player>().currHP -= 0.5f;


        }
    }
}

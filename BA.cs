using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAxe : MonoBehaviour
{
    public float health = 100.0f;
    public RectTransform healthbar;
    public float damage = 12.0f;
    bool right = true;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1.0f)
        {
            die();
        }
        healthbar.sizeDelta = new Vector2(health / 2, healthbar.sizeDelta.y);
        if (right)
        {
            transform.position = new Vector3(transform.position.x + .2f, 0, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - .2f, 0, transform.position.z);
        }

    }

    void die()
    {
        Destroy(this.gameObject);
    }
}

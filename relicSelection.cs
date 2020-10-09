using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class relicSelection : MonoBehaviour, IPointerClickHandler
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("BlackBull");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //when we click the relic we choose, apply its effects based on the tag. Break and deactivate the canvas that all the buttons belong to.
        //reset the booleans in the wave controller to allow more enemies to spawn.
        switch (this.gameObject.tag)
        {
            case ("speedRelic"):
                player.GetComponent<Player>().speed = player.GetComponent<Player>().speed * 1.3f;
                break;
            case ("cdrRelic"):
                player.GetComponent<shooting>().specialCD = player.GetComponent<shooting>().specialCD * 0.6f;
                player.GetComponent<shooting>().altCD = player.GetComponent<shooting>().altCD * 0.6f;
                break;
            case ("bulletRelic"):
                player.GetComponent<shooting>().fireRate = player.GetComponent<shooting>().fireRate * 0.5f;
                break;
        }
        GameObject.Find("relicCanvas").SetActive(false);
        GameObject.Find("WaveController").GetComponent<Waves>().unlocked = false;
        GameObject.Find("WaveController").GetComponent<Waves>().deciding = false;
        Destroy(this.gameObject);
    } 
}

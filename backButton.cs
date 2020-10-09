using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject shopMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //we need to hide the shop menu to preserve data, and change the scene.
        shopMenu.SetActive(false);
        SceneManager.LoadScene("mainMenu");
    }
}

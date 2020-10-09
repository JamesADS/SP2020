using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class upgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Texture highlight;
    public Texture original;

    private bool mouseover = false;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mouseover)
        {
            replaceImage();
        }

        if (!mouseover)
        {
            putImageBack();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseover = true;
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseover = false;
        Debug.Log("Mouse exit");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        SceneManager.LoadScene("shop");
    }


    /**/
    /*
    void replaceImage()

    NAME



    SYNOPSIS


    DESCRIPTION

        switch the image of the a button when we hover over it.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/15/2020

    */
    /**/
    void replaceImage()
    {

        RawImage current = this.gameObject.GetComponent<RawImage>();
        current.texture = highlight;

    }
    /**/
    /*
    void putImageBack()

    NAME



    SYNOPSIS


    DESCRIPTION

        switch the image of a button when we stop hovering over it.

    RETURNS



    AUTHOR

        James P Giordano

    DATE

        9/15/2020

    */
    /**/
    void putImageBack()
    {

        RawImage current = this.gameObject.GetComponent<RawImage>();
        current.texture = original;

    }

}


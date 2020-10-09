using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class shipSelectButton : MonoBehaviour, IPointerClickHandler
{
    public string selected;
    public RectTransform speedBar;
    public RectTransform fireBar;
    public RectTransform utilityBar;

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
        //used for the ship selection button of the Black Bull. Sets the UI accordingly.
        selected = "BlackBull";
        speedBar.sizeDelta = new Vector2(200, speedBar.sizeDelta.y);
        fireBar.sizeDelta = new Vector2(400,  fireBar.sizeDelta.y);
        utilityBar.sizeDelta = new Vector2(80, utilityBar.sizeDelta.y);
    }
}

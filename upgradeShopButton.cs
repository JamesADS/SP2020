using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class upgradeShopButton : MonoBehaviour, IPointerClickHandler
{
    public RectTransform barProgress;
    public TextMeshProUGUI textPercent;
    private float barSegments;
    private bool doneUpgrading = false;
    public int percentChange;
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
        //confirm the player has enough resources to make this purchase.
        if (doneUpgrading)
        {
            
        }
        barProgress.sizeDelta = new Vector2(barProgress.sizeDelta.x + 52, barProgress.sizeDelta.y);

        //stop the bar from overflowing on the UI if this is the last upgrade.
        if (barProgress.sizeDelta.x > 590)
        {
            barProgress.sizeDelta = new Vector2(590, barProgress.sizeDelta.y);
            doneUpgrading = true;
        }

        //fill the bar based on the amount of purchases.
        barSegments = Mathf.Ceil((barProgress.sizeDelta.x - 35) / 52);
        if (percentChange > 0)
        {
            textPercent.text = "+" + (barSegments * percentChange).ToString() + "%";
        }
        else
        {
            textPercent.text = (barSegments * percentChange).ToString() + "%";
        }
    }

    
}

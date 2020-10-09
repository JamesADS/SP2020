using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dropBehavior : MonoBehaviour
{
    public TextMeshProUGUI plusText;
    public RawImage itemImg;
    private float myTime;
    bool fade = false;
    // Start is called before the first frame update
    void Start()
    {
        itemImg = this.gameObject.GetComponent<RawImage>();
        Invoke("fading", 0.5f);
    }

    // Update is called once per frame
    /*
     * This script is to be attached to the images that drop from basic enemies. It causes them to fade out at a regulated rate and also move up slowly. It creates a nice effect, and we destroy the image after it has fully
     faded out.
     */
    void Update()
    {
        if (fade && myTime > 0.1f)
        {
            Color current = plusText.color;
            current.a -= 0.08f;
            plusText.color = current;
            current = itemImg.color;
            current.a -= 0.08f;
            itemImg.color = current;
            myTime = 0.0f;
        }
        if (plusText.color.a == 0 && itemImg.color.a == 0)
        {
            Destroy(this.gameObject);
        }
        myTime += Time.deltaTime;
        this.gameObject.transform.position += new Vector3(0, 0, 0.01f);
    }

    void fading()
    {
        fade = true;
    }
}

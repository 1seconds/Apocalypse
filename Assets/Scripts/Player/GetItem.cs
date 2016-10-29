using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetItem : MonoBehaviour
{
    public GameObject displayItem;
    public GameObject displayKey;

    void OnTriggerEnter2D(Collider2D obj)
    {
        //모래시계 get
        if(obj.tag == "Item" && obj.name.Contains("SandClock"))
        {
            displayItem.GetComponent<Image>().sprite = GameObject.FindWithTag("MainCamera").GetComponent<ItemCollection>().heart_Image;
            //효과
        }

        //폭탄 get
        if (obj.tag == "Item" && obj.name.Contains("Bomb"))
        {
            displayItem.GetComponent<Image>().sprite = GameObject.FindWithTag("MainCamera").GetComponent<ItemCollection>().bomb_Image;
            //효과
        }

        //열쇠 get
        if (obj.tag == "Item" && obj.name.Contains("Bomb"))
        {
            displayKey.GetComponent<Image>().sprite = GameObject.FindWithTag("MainCamera").GetComponent<ItemCollection>().key_Image;
            //효과
        }
    }
}

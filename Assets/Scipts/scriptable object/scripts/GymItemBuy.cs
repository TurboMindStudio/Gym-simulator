using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GymItemBuy
{
    public string Itemname;
    public int price;
    public Sprite GymItem;


    //text
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI cardPrice;
    public Image cardImg;

}

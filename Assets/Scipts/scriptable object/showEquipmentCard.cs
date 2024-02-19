using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class showEquipmentCard : MonoBehaviour
{

    public static showEquipmentCard instance;

    public GameObject card;
    public GameObject playerCanvs;
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI cardPrice;
    public Image cardImg;

    public GymItemBuy[] gymItemBuy;
   

    private void Awake()
    {
        instance = this;
    }



    private void Start()
    {
        for (int i = 0; i < gymItemBuy.Length; i++)
        {
            gymItemBuy[i].cardName.text = "Name : " + gymItemBuy[i].Itemname;
            gymItemBuy[i].cardPrice.text = "Price : " + gymItemBuy[i].price.ToString() + "Rs";
            gymItemBuy[i].cardImg.sprite = gymItemBuy[i].GymItem;
        }
       
        


       
    }
    public void showCardDetails(gymEquipment carddata)
    {
        cardName.text = "Name : " + carddata.EquipmentName;
        cardPrice.text = "Price : " + carddata.EquipmentPrice.ToString() + "Rs";
        cardImg.sprite = carddata.EquipmentImg;
    }

    public void closeCard()
    {
        card.SetActive(false);
        playerCanvs.SetActive(true);
    }
}

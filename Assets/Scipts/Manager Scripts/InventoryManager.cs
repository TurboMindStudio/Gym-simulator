using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;

public class InventoryManager : MonoBehaviour
{
    public gymEquipment[] asd;
    public GameObject InventoryItemPrefab;
    public GameObject InventoryContentPanel;
    public GameObject[] ItemBuy;
    private int Count = 0;
    public Image[] ItemImg;

    private void Start()
    {
        
    }
    public void BuyItem(gymEquipment itemBuyInfo)
    {
        if (itemBuyInfo.EquipmentCount <= 0)
        {
            ItemBuy[Count] = Instantiate(InventoryItemPrefab, InventoryContentPanel.transform) as GameObject;
            TextMeshProUGUI[] ItemText = ItemBuy[Count].GetComponentsInChildren<TextMeshProUGUI>();
            ItemImg = ItemBuy[Count].GetComponentsInChildren<Image>();
            Count++;
            ItemImg[1].sprite = itemBuyInfo.EquipmentImg;
            itemBuyInfo.EquipmentCount++;
            ItemText[0].text = itemBuyInfo.EquipmentCount.ToString();
            ItemText[1].text = itemBuyInfo.EquipmentName;
        }
        else if (itemBuyInfo.EquipmentCount > 0)
        {

            for (int i = 0; i < ItemBuy.Length; i++)
            {
                TextMeshProUGUI[] ItemText = ItemBuy[i].GetComponentsInChildren<TextMeshProUGUI>();
                if (ItemText[1].text == itemBuyInfo.EquipmentName)
                {
                    itemBuyInfo.EquipmentCount++;
                    ItemText[0].text=itemBuyInfo.EquipmentCount.ToString();
                }
            }
        }
        
    }
}

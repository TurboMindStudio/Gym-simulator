using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;

public class InventoryManager : MonoBehaviour
{

    public GameObject InventoryItemPrefab;
    public GameObject InventoryContentPanel;
    public List<GameObject> ItemBuy = new List<GameObject>();

    public int count=0;

    public gymEquipment[] equipmentGym;
  

    private void Start()
    {
        for (int i = 0; i < equipmentGym.Length; i++)
        {
            if (equipmentGym[i].EquipmentCount>0)
            {
                
                InstantiateItem(equipmentGym[i]);
                UiManager.instance.InventoryWarning.gameObject.SetActive(false);

            }
            else if(equipmentGym[i].EquipmentCount < 0)
            {
                UiManager.instance.InventoryWarning.gameObject.SetActive(true);
            }
        }
    }

    public void InstantiateItem(gymEquipment itemBuyInfo)
    {
        GameObject temp = Instantiate(InventoryItemPrefab, InventoryContentPanel.transform) as GameObject;
        ItemBuy.Add(temp);

        TextMeshProUGUI[] ItemText = ItemBuy[count].GetComponentsInChildren<TextMeshProUGUI>();
        ItemText[1].text = itemBuyInfo.EquipmentName;
        ItemText[0].text = itemBuyInfo.EquipmentCount.ToString();

        Image[] ItemImg = ItemBuy[count].GetComponentsInChildren<Image>();
        ItemImg[1].sprite = itemBuyInfo.EquipmentImg;

        itemBuyInfo.isInstantiated = true;
        count++;
        
    }
    public void BuyItem(gymEquipment itemBuyInfo)
    {
        if (CashManager.instance.WalletBalance >= itemBuyInfo.EquipmentPrice)
        {
            CashManager.instance.WalletBalance -= itemBuyInfo.EquipmentPrice;
            UiManager.instance.UpdateInfoText(itemBuyInfo.EquipmentName + " added in inventory.");
            CashManager.instance.walletBalanceText.text= "Rs : " + CashManager.instance.WalletBalance.ToString();
            AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.cashDeductsfx);


            if (itemBuyInfo.isInstantiated == false)
            {
                GameObject temp = Instantiate(InventoryItemPrefab, InventoryContentPanel.transform) as GameObject;
                ItemBuy.Add(temp);

                TextMeshProUGUI[] ItemText = ItemBuy[count].GetComponentsInChildren<TextMeshProUGUI>();
                ItemText[1].text = itemBuyInfo.EquipmentName;

                Image[] ItemImg = ItemBuy[count].GetComponentsInChildren<Image>();
                ItemImg[1].sprite = itemBuyInfo.EquipmentImg;

                itemBuyInfo.isInstantiated = true;
                count++;

            }
            else
            {
                /*TextMeshProUGUI[] Itemtext = ItemBuy[count].GetComponentsInChildren<TextMeshProUGUI>();
                itemBuyInfo.EquipmentCount++;
                Itemtext[0].text = itemBuyInfo.EquipmentCount.ToString(); */
                Debug.Log("count Increase");
                Debug.Log(ItemBuy.Count);

                for (int i = 0; i < ItemBuy.Count; i++)
                {
                    TextMeshProUGUI[] Itemtext = ItemBuy[i].GetComponentsInChildren<TextMeshProUGUI>();
                    if (Itemtext[1].text == itemBuyInfo.EquipmentName)
                    {
                        string temp = Itemtext[0].text;
                        int count = int.Parse(temp);
                        count++;
                        Itemtext[0].text = "" + count;
                        itemBuyInfo.EquipmentCount = count;
                    }
                }
            }
        }
        else
        {
            Debug.Log("You have not Enough Money");
            UiManager.instance.UpdateInfoText("You have InSufficient Cash.");
            AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.errorsfx);
        }

    }
}

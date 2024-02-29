using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public GameObject computerPanel;
    public TextMeshProUGUI infoText;
    public GameObject InventoryWarning;

    //name plate
    public TMP_InputField nameInputFeild;
    public TextMeshProUGUI BoardName;
    private void Awake()
    {
        instance = this;
    }

    public void UpdateInfoText(string text)
    {
        infoText.gameObject.SetActive(true);
        infoText.text = text;
    }

    public void ChangeNamePlate()
    {
       BoardName.text = nameInputFeild.text;
       
    }
}

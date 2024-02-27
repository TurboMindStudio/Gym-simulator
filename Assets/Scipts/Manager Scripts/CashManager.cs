using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;
    public TextMeshProUGUI walletBalanceText;
    public int WalletBalance;

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        walletBalanceText.text = "Rs : " + WalletBalance.ToString();
    }

}

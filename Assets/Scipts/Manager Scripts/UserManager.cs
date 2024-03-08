using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UserManager : MonoBehaviour
{
    public static UserManager instance;
    public NpcScriptable[] GymMembers;
    public int RandomMemberName;

    public TextMeshProUGUI MemberNameText;
    public GameObject memberShipPanel;
    public GameObject gymMemberPanel;

    public GameObject warningTxt;
    public Button UserButton;

    public bool MemberJoined;


    public void Awake()
    {
        instance = this;
        memberShipPanel.SetActive(false);
    }

    public void UpdateMemberData()
    {
        memberShipPanel.SetActive(true);
        Debug.Log("active member");
    }

    public void JoinMember(int moneyAdded)
    {
        CashManager.instance.WalletBalance += moneyAdded;
        CashManager.instance.walletBalanceText.text = "Rs : " + CashManager.instance.WalletBalance.ToString();
        memberShipPanel.SetActive(false);
        gymMemberPanel.SetActive(false);
        AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.cashDeductsfx);
        MemberJoined = true;



    }
}

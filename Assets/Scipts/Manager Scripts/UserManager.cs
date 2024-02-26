using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UserManager : MonoBehaviour
{
    public static UserManager instance;
    public NpcScriptable[] GymMembers;
    private int RandomMemberName;

    public TextMeshProUGUI MemberNameText;
    public GameObject memberShipPanel;

    public GameObject warningTxt;
    public Button UserButton;
    

    public void Awake()
    {
        instance = this;
        memberShipPanel.SetActive(false);
    }
    

    public void UpdateMemberData()
    {
        memberShipPanel.SetActive(true);
        warningTxt.SetActive(false);
        RandomMemberName = Random.Range(0, GymMembers.Length);
        MemberNameText.text = GymMembers[RandomMemberName].Name.ToString();
        Debug.Log(GymMembers[RandomMemberName].Name);
    }
}

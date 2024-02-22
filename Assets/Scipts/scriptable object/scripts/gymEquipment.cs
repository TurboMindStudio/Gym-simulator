using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Data",menuName = "GymEquipment")]
public class gymEquipment : ScriptableObject
{
    public string EquipmentName;
    public int EquipmentPrice;
    public Sprite EquipmentImg;
}

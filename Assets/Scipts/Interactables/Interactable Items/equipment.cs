using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class equipment : Interactable
{
    public gymEquipment cardData;
    public PickUp pickUp;

    
    protected override void Interact()
    {
       // Debug.Log(this.gameObject.name);
       // showEquipmentCard.instance.showCardDetails(cardData);
      //  showEquipmentCard.instance.card.SetActive(true);
        //showEquipmentCard.instance.playerCanvs.SetActive(false);

        pickUp.pickItem();
       
    }
}

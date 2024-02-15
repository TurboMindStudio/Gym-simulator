using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computer : Interactable
{
   
    protected override void Interact()
    {
        UiManager.instance.computerPanel.SetActive(true);
    }
}

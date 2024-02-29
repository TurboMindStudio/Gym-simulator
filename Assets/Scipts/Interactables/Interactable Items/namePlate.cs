using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class namePlate : Interactable
{
    public GameObject nameplatePanel;
    protected override void Interact()
    {
        nameplatePanel.SetActive(true);
    }
}

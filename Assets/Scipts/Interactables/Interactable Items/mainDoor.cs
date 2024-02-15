using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainDoor : Interactable
{
    public Animator animator;
    bool doorOpen;
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        if (doorOpen)
        {
            animator.SetBool("DoorOpen", true);
        }
        else if (!doorOpen)
        {
            animator.SetBool("DoorOpen", false);
        }
    }
}

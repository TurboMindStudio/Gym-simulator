using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memberJoinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            Debug.Log("Got Member");
        }
    }
}

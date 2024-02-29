using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCan : MonoBehaviour
{
    public int trashCount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("equipment"))
        {
            Destroy(other.gameObject);
            trashCount++;

            if (trashCount >= 13)
            {
                Debug.Log("All trash Collected");
            }
        }
    }
}

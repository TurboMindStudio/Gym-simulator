using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public GameObject computerPanel;
    private void Awake()
    {
        instance = this;
    }
}

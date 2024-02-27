using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource audioSource;
    public AudioClip cashDeductsfx;
    public AudioClip errorsfx;

    private void Awake()
    {
        Instance = this;
    }
}

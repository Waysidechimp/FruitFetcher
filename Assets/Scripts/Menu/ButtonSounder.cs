using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounder : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.Play(0);
    }
}

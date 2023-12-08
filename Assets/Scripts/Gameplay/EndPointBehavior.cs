using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointBehavior : MonoBehaviour
{
    GameObject transition;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        transition = GameObject.FindGameObjectWithTag("Transition");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Play();
            transition.GetComponent<TransitionInScript>().TransitionOut();
        }
    }
}

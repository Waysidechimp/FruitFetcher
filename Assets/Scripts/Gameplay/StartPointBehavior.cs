using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointBehavior : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("isTouched");
    }

    void ResetAnimation(string trigger)
    {
        animator.SetTrigger("isNotTouched");
    }
}

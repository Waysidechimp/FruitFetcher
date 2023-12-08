using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    PointManager pointManager;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    [SerializeField] ParticleSystem particles;
    bool isTriggerUsed = false;

    [SerializeField]
    public int pointValue;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        pointManager = GameObject.FindGameObjectWithTag("PManager").GetComponent<PointManager>();
        particles = GetComponent<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTriggerUsed)
        {
            audioSource.Play();
            isTriggerUsed = true;
            spriteRenderer.enabled = false;
            particles.Play();
            pointManager.AddPoint(pointValue);

            Invoke("RemoveGameobject", 1.5f);
        }
    }

    void RemoveGameobject()
    {
        Destroy(gameObject);
    }
}

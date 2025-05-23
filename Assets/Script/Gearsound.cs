using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gearsound : MonoBehaviour
{
    public float minPitch = 0.8f;
    public float maxPitch = 2.0f;
    public float maxSpeed = 20f;

    private AudioSource audioSource;
    private Rigidbody2D rb;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

        if (!audioSource.isPlaying)
        {
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void Update()
    {
        float speed = rb.velocity.magnitude;

        float pitch = Mathf.Lerp(minPitch, maxPitch, speed / maxSpeed);
        audioSource.pitch = pitch;
    }
}

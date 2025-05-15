using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsPlayer : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] footsteps;
    public float pitchoffset = 0.1f;

    private void Start()
    {
        InvokeRepeating(nameof(PlayFootstep), 0.1f, 1f);
    }

    public void PlayFootstep()
    {
        AudioClip soundtoPlay = footsteps[Random.Range(0, footsteps.Length)];
        source.Stop();
        source.clip = soundtoPlay;
        source.pitch = 1f + Random.Range(-pitchoffset, pitchoffset);
        source.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;




public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer SR1;
    public Light2D Light2D;
    public Canvas canvas;

    public void Start()
    {
        Light2D.enabled = false;
        canvas.enabled = false ;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out _))
        {
            Light2D.enabled = true;
            canvas.enabled = true;
            SR1.enabled = false;

            return;
        }
    }
}

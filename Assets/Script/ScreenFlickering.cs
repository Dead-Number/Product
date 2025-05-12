using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;
using TMPro;
using UnityEngine.InputSystem;
using System.Security.Cryptography;

public class ScreenFlickering : MonoBehaviour
{

    public float minIntensity = 0.5f;
    public float duration = 0.1f;
    public int numberLoops = -1;
    public LoopType _loopType = LoopType.Yoyo;

    public AnimationCurve curve;
    public Light2D light2D;
    public SpriteRenderer SR;

    public LayerMask _layer;

    public float radius = 2.0f;
    public float _wait = 1.5f;

    public GameObject player;

    public void Start()
    {
        light2D.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out _))
        {

            light2D.enabled = true;
            SR.enabled = false;

            DOTween.To(() => light2D.intensity, (value) => light2D.intensity = value, minIntensity, duration)
                .SetEase(curve)
                .SetLoops(numberLoops, _loopType);

            return;
        }
    }
}


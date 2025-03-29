using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectMove : MonoBehaviour
{
    public float posFinal = 5.0f;
    public float _duration = 2.0f;
    public Ease AnimType;

    private void OnEnable()
    {
        transform.DOMoveY(posFinal, _duration)
            .SetEase(AnimType);
    }

    private void OnDisable()
    {
        Vector2 posInit = transform.position;

        transform.DOMoveY(posInit.y, _duration)
            .SetEase(AnimType);
    }
}

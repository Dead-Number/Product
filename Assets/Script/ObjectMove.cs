using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectMove : MonoBehaviour
{
    public float posFinal = 5.0f;
    public float posInit = 0f;
    public float _duration = 2.0f;
    public Ease AnimType;

    public void DoorOpen()
    {
        transform.DOMoveY(posFinal, _duration)
            .SetEase(AnimType);
    }

    public void DoorClose()
    {
        transform.DOMoveY(posInit, _duration)
            .SetEase(AnimType);
    }
}

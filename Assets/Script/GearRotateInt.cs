using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GearRotateInt : MonoBehaviour
{
    public float _duration = 5.0f;
    public Vector3 _rotation;
    public Ease _AnimType;

    public void Activation()
    {
        transform.DORotate(_rotation, _duration)
            .SetRelative()
            .SetEase(_AnimType);
    }
}

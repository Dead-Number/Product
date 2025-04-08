using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GearRotate : MonoBehaviour
{

    public float _duration = 5.0f;
    public Vector3 _rotation;
    public LoopType _looptype;
    public Ease _AnimType;

    void Start()
    {
        transform.DORotate (_rotation, _duration)
            .SetLoops(-1, _looptype)
            .SetRelative()
            .SetEase(_AnimType);
    }
}

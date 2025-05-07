using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Trapdetect : MonoBehaviour
{

    public float posFinal = -7.1f;
    public float _duration = 0.5f;

    public Ease AnimType;
    public LoopType LoopType;

    void Start()
    {
        transform.DOMoveY(posFinal, _duration)
            .SetLoops(-1, LoopType)
            .SetRelative()
            .SetEase(AnimType);
    }
}

using DG.Tweening;
using UnityEngine;

public class Trapdetect : MonoBehaviour
{

    public float posFinal;
    public float _duration;

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

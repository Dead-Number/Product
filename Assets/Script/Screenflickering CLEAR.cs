using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class ScreenflickeringCLEAR : MonoBehaviour
{
    public float minIntensity = 0.5f;
    public float duration = 0.1f;
    public int numberLoops = -1;
    public LoopType _loopType = LoopType.Yoyo;
    public AnimationCurve curve;

    public Light2D light2D;

    public void Start()
    {

        DOTween.To(() => light2D.intensity, (value) => light2D.intensity = value, minIntensity, duration)
            .SetEase(curve)
            .SetLoops(numberLoops, _loopType);

        return; ;
    }
}

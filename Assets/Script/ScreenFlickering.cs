using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class ScreenFlickering : MonoBehaviour
{

    public float minIntensity = 0.5f;
    public float duration = 0.1f;
    public Ease easing = Ease.Linear;
    public int numberLoops = -1;
    public LoopType _loopType = LoopType.Yoyo;

    public Light2D _light2D;

    private void Start()
    {

        DOTween.To(() => _light2D.intensity, (value) => _light2D.intensity = value, minIntensity, duration)
            .SetEase(easing)
            .SetLoops(numberLoops, _loopType);
    }
}

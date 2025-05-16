using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class SparkFlickerDoor : MonoBehaviour
{
    public float minIntensity = 0.5f;
    public float duration = 0.1f;
    public Ease easing = Ease.Linear;
    public int numberLoops = -1;
    public LoopType _loopType = LoopType.Yoyo;

    private float inputDirection;
    public Light2D light2D;
    private Tween sparkAnim;

    public ParticleSystem particle;

    public float wait;

    public void Awake()
    {

        sparkAnim = DOTween.To(() => light2D.intensity, (value) => light2D.intensity = value, minIntensity, duration)
                    .SetEase(easing)
                    .SetLoops(numberLoops, _loopType);

        sparkAnim.Pause();

        light2D.enabled = false;

        particle.enableEmission = false;
    }


    public void Activate()
    {
        StartCoroutine(PlayStopSpark());
    }

    public IEnumerator PlayStopSpark()
    {
        light2D.enabled = true;
        sparkAnim.Play();
        particle.enableEmission = true;

        yield return new WaitForSeconds(wait);

        light2D.enabled = false;
        sparkAnim.Pause();
        particle.enableEmission = false;
    }
}


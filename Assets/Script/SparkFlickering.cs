using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class SparkFlickering : MonoBehaviour
{

    public float minIntensity = 0.5f;
    public float duration = 0.1f;
    public Ease easing = Ease.Linear;
    public int numberLoops = -1;
    public LoopType _loopType = LoopType.Yoyo;

    public Rigidbody2D rb;

    private float inputDirection;
    private Light2D _light2D;

    private void Awake()
    {
        _light2D = GetComponent<Light2D>();
    }

    void Update()
    {
        inputDirection = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (inputDirection > 0)
        {
            if (Mathf.Sign(rb.angularVelocity) < 0)
            {
                DOTween.To(() => _light2D.intensity, (value) => _light2D.intensity = value, minIntensity, duration)
                    .SetEase(easing)
                    .SetLoops(numberLoops, _loopType);
            }

            else
            {

            }
        }

        else
        {

        }

        if (inputDirection < 0)
        {
            if (Mathf.Sign(rb.angularVelocity) > 0)
            {
                DOTween.To(() => _light2D.intensity, (value) => _light2D.intensity = value, minIntensity, duration)
                    .SetEase(easing)
                    .SetLoops(numberLoops, _loopType);
            }

            else
            {

            }
        }

        else
        {

        }
    }
}

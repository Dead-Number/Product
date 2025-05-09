using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{

    public Transform CamTransform;

    public void Activation()

    {
        CamTransform.DOShakePosition(2f, 0.25f, 40, 30f);

        StartCoroutine(ShakeDelay());
    }

    IEnumerator ShakeDelay()

    {
        yield return new WaitForSeconds(2);

        CamTransform.DOShakePosition(0.25f, 0.75f, 40, 30f);
    }

    public void ActivationTwo()
    {
        StartCoroutine(ShakeDelayTwo());
    }

    IEnumerator ShakeDelayTwo()
    {
        yield return new WaitForSeconds(3.3f);

        CamTransform.DOShakePosition(0.25f, 0.5f, 40, 30f);
    }
}

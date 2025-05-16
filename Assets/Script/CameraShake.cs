using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{

    public Transform CamTransform;

    public void Activation()
    {
        StartCoroutine(ShakeDelay());
    }

    IEnumerator ShakeDelay()
    {
        yield return new WaitForSeconds(1.5f);

        CamTransform.DOShakePosition(0.25f, 0.50f, 40, 30f);

        yield return new WaitForSeconds(1f);

        CamTransform.DOShakePosition(0.25f, 0.50f, 40, 30f);

        yield return new WaitForSeconds(1f);

        CamTransform.DOShakePosition(0.25f, 0.50f, 40, 30f);
    }

    public void ActivationTwo()
    {
        StartCoroutine(ShakeDelayTwo());
    }

    IEnumerator ShakeDelayTwo()
    {
        yield return new WaitForSeconds(7f);

        CamTransform.DOShakePosition(0.25f, 0.5f, 40, 30f);
    }

    public void ActivationThree()

    {
        CamTransform.DOShakePosition(2f, 0.25f, 40, 30f);

        StartCoroutine(ShakeDelayThree());
    }

    IEnumerator ShakeDelayThree()

    {
        yield return new WaitForSeconds(2);

        CamTransform.DOShakePosition(0.25f, 0.75f, 40, 30f);
    }
}

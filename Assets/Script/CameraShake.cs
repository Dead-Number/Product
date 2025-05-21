using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{

    public Transform CamTransform;
    public AudioSource screech;
    public AudioSource clank_1;
    public AudioSource clank_2;
    public AudioSource clank_3;
    public AudioSource clank_4;
    public AudioSource clank_5;
    public AudioSource clank_6;

    public void Activation()
    {
        StartCoroutine(ShakeDelay());
    }

    IEnumerator ShakeDelay()
    {
        GetComponent<CameraFollow>().enabled = false;

        yield return new WaitForSeconds(1.5f);

        CamTransform.DOShakePosition(0.25f, 0.50f, 40, 30f);

        clank_1.Play();

        yield return new WaitForSeconds(1f);

        CamTransform.DOShakePosition(0.25f, 0.50f, 40, 30f);

        clank_1.Pause();
        clank_2.Play();

        yield return new WaitForSeconds(1f);

        CamTransform.DOShakePosition(0.25f, 0.50f, 40, 30f);

        clank_2.Pause();
        clank_3.Play();

        yield return new WaitForSeconds(0.25f);

        GetComponent<CameraFollow>().enabled = true;

        yield return new WaitForSeconds(0.75f);

        clank_3.Pause();

    }

    public void ActivationTwo()
    {
        StartCoroutine(ShakeDelayTwo());
    }

    IEnumerator ShakeDelayTwo()
    {
        GetComponent<CameraFollow>().enabled = false;

        yield return new WaitForSeconds(7f);

        CamTransform.DOShakePosition(0.25f, 0.5f, 40, 30f);

        yield return new WaitForSeconds(0.25f);

        GetComponent<CameraFollow>().enabled = true;
    }

    public void ActivationThree()

    {
        screech.Play();

        CamTransform.DOShakePosition(2f, 0.25f, 40, 30f);

        StartCoroutine(ShakeDelayThree());
    }

    IEnumerator ShakeDelayThree()

    {
        GetComponent<CameraFollow>().enabled = false;

        yield return new WaitForSeconds(2);

        screech.Pause();
        clank_1.Play();

        CamTransform.DOShakePosition(0.25f, 0.75f, 40, 30f);

        yield return new WaitForSeconds(0.25f);

        GetComponent<CameraFollow>().enabled = true;

        yield return new WaitForSeconds(0.75f);

        clank_1.Pause();
    }

    public void ActivationFour()
    {
        StartCoroutine(ShakeDelayFour());
    }

    IEnumerator ShakeDelayFour()
    {
        GetComponent<CameraFollow>().enabled = false;

        yield return new WaitForSeconds(3.5f);

        CamTransform.DOShakePosition(0.25f, 0.5f, 40, 30f);

        yield return new WaitForSeconds(0.25f);

        GetComponent<CameraFollow>().enabled = true;
    }
}

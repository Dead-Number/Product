using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotateWait : MonoBehaviour
{
    public float _duration = 5.0f;
    public float wait;
    public Vector3 _rotation;
    public Ease _AnimType;

    public void Activation()
    {
        StartCoroutine(WaitGear());
    }

    IEnumerator WaitGear()
    {
        yield return new WaitForSeconds(wait);

        transform.DORotate(_rotation, _duration)
            .SetRelative()
            .SetEase(_AnimType);
    }
}

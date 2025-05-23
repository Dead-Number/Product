using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Trapdetect : MonoBehaviour
{

    public float posFinal;
    public float _duration;
    public float wait;

    public Ease AnimType;
    public LoopType LoopType;

    public AudioSource AudioSource;

    void Start()
    {
        transform.DOMoveY(posFinal, _duration)
            .SetLoops(-1, LoopType)
            .SetRelative()
            .SetEase(AnimType);

        StartCoroutine(TrapSoundDelay());
    }

    IEnumerator TrapSoundDelay()
    {
        while (true)

        {
            yield return new WaitForSeconds(wait);

            AudioSource.Play();

            yield return new WaitForSeconds(wait);
        }
    }
}

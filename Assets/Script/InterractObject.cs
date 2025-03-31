using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InterractObject : MonoBehaviour
{

    public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    private bool isActive;

    public SpriteRenderer _spriteRdr;
    public float _colorSwapDuration;

    public void Activate()
    {
        isActive = !isActive;

        if (isActive)
        {
            onActivate?.Invoke();
            _spriteRdr.DOColor(Color.red, _colorSwapDuration);

        }

        else
        {
            onDeactivate?.Invoke();
            _spriteRdr.DOColor(Color.white, _colorSwapDuration);
        }
    }

}

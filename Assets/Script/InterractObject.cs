using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractObject : MonoBehaviour
{

    public SpriteRenderer _spriteRdr;
    public float _colorSwapDuration;

    public void Activate()
    {
        _spriteRdr.DOColor(Color.red, _colorSwapDuration);
    }
}

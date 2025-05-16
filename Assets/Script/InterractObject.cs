using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class InterractObject : MonoBehaviour
{

    public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    private bool isActive;

    public SpriteRenderer _spriteRdr;

    public Rigidbody2D _body2D;
    public GameObject button;
    public GameObject _player;
    public GameObject G1;
    public GameObject G2;
    public Vector2 _interactDestination;
    public PlayerInput PI;

    public float _duration = 5.0f;
    public Vector3 _rotation;
    public Vector3 _rotationI;
    public Ease _AnimType;

    public float _wait = 1.5f;
    public float _wait2 = 2.5f;
    public float _wait3 = 2.5f;

    public Light2D light2D;
    public SpriteRenderer SR;
    public SpriteRenderer sptRdr;
    public Sprite Gear;

    public Collider2D collider2D1;

    public void Activate()
    {
        if (sptRdr.sprite == Gear)
        {
            isActive = !isActive;

            if (isActive)
            {
                _body2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                _body2D.velocity = Vector2.zero;
                _body2D.isKinematic = true;
                _player.transform.position = _interactDestination;

                PI.actions["Move"].Disable();
                PI.actions["Interract"].Disable();
                PI.actions["Swap"].Disable();
                PI.actions["Menu"].Disable();

                StartCoroutine(GateAnimation());
            }

            else
            {

            }
        }
           
    }

    public IEnumerator GateAnimation()
    {
        yield return new WaitForSeconds(_wait);

        _player.transform.DORotate(_rotation, _duration)
            .SetRelative()
            .SetEase(_AnimType);

        G1.transform.DORotate(_rotationI, _duration)
            .SetRelative()
            .SetEase(_AnimType);

        G2.transform.DORotate(_rotationI, _duration)
            .SetRelative()
            .SetEase(_AnimType);

        yield return new WaitForSeconds(_wait2);

        onActivate?.Invoke();

        yield return new WaitForSeconds(_wait3);

        _body2D.isKinematic = false;
        _body2D.constraints = RigidbodyConstraints2D.None;

        button.SetActive(false);

        light2D.enabled = false;
        SR.enabled = true;

        collider2D1.enabled = false;

        PI.actions["Move"].Enable();
        PI.actions["Interract"].Enable();
        PI.actions["Swap"].Enable();
        PI.actions["Menu"].Enable();

    }
}

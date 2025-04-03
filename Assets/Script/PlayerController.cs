using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController : MonoBehaviour
{
    public float radius = 2.0f;
    public float impulse = 20.0f;

    public Sprite _gearZero;
    public Sprite _gearOne;
    public Sprite _gearTwo;

    private float _axis;

    public SpriteRenderer _sptRdr;

    private void Start()
    {
        _sptRdr.sprite = _gearZero;
    }

    public void Update()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.AddTorque(-impulse * _axis);
    }

    private void OnMove(InputValue value)
    {
        _axis = value.Get<float>();
    }

    private void OnInterract()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in colliders)
        {
            InterractObject InterractObjectComponent = collider.GetComponent<InterractObject>();

            if (InterractObjectComponent != null)
            {
                InterractObjectComponent.Activate();
                return;
            }
        }

    }
    private void OnSwap()
    {
        if (_sptRdr.sprite == _gearZero)
        {
            _sptRdr.sprite = _gearOne;
            return;
        }

        if (_sptRdr.sprite == _gearOne)
        {
            _sptRdr.sprite = _gearTwo;
            return;
        }

        if (_sptRdr.sprite == _gearTwo)
        {
            _sptRdr.sprite = _gearZero;
            return;
        }
    }
}
 
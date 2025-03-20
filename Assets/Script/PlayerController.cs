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

    private float _axis;

    public void Update()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.AddTorque(-impulse * _axis);
    }

    private void OnMove(InputValue value)
    {
        _axis = value.Get<float>();
    }

    private void OnSecondary()
    {

    }

    private void OnInterract()
    {

    }

    private void OnSwap()
    {

    }
}

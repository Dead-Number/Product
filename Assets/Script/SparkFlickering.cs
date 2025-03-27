using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class SparkFlickering : MonoBehaviour
{

    public float minIntensity = 0.5f;
    public float duration = 0.1f;
    public Ease easing = Ease.Linear;
    public int numberLoops = -1;
    public LoopType _loopType = LoopType.Yoyo;

    public Rigidbody2D rb;

    private float inputDirection;
    private Light2D _light2D;
    private Tween _sparkAnim;

    public float _groundCheckDistance = 0.1f;
    public LayerMask _ground;
    private bool _isGrounded;

    private void Awake()
    {
        _light2D = GetComponent<Light2D>();

        _sparkAnim = DOTween.To(() => _light2D.intensity, (value) => _light2D.intensity = value, minIntensity, duration)
                    .SetEase(easing)
                    .SetLoops(numberLoops, _loopType);

        _sparkAnim.Pause();

        _light2D.enabled = false;
    }

    void Update()
    {
        inputDirection = Input.GetAxis("Horizontal");

        Vector2 _playerPos = new Vector2(transform.position.x, transform.position.y);

        _isGrounded = Physics2D.Raycast(_playerPos, Vector2.down, _groundCheckDistance, _ground);

        Debug.DrawRay(_playerPos, Vector2.down * _groundCheckDistance, Color.red);
    }

    private void FixedUpdate()
    {
        if (inputDirection > 0)
        {
            if (Mathf.Sign(rb.angularVelocity) > 0 && _isGrounded)
            {
                _light2D.enabled = true;

                _sparkAnim.Play();

                return;
            }
        }

        _sparkAnim.Pause();

        _light2D.enabled = false;

        if (inputDirection < 0)
        {
            if (Mathf.Sign(rb.angularVelocity) < 0 && _isGrounded) 
            {
                _light2D.enabled = true;

                _sparkAnim.Play();

                return;
            }
        }

        _sparkAnim.Pause();

        _light2D.enabled = false;
    }
}

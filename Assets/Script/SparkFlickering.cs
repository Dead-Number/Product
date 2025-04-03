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
    public Light2D _light2D;
    public Light2D _rightlight2D;
    private Tween _sparkAnim;
    private Tween _rightsparkAnim;

    public float _groundCheckDistance = 0.1f;
    public LayerMask _ground;
    private bool _isGrounded;

    public ParticleSystem _particle;
    public ParticleSystem _rightparticle;

    private void Awake()
    {

        _sparkAnim = DOTween.To(() => _light2D.intensity, (value) => _light2D.intensity = value, minIntensity, duration)
                    .SetEase(easing)
                    .SetLoops(numberLoops, _loopType);

        _sparkAnim.Pause();

        _rightlight2D.enabled = false;


        _rightsparkAnim = DOTween.To(() => _rightlight2D.intensity, (value) => _rightlight2D.intensity = value, minIntensity, duration)
                    .SetEase(easing)
                    .SetLoops(numberLoops, _loopType);

        _rightsparkAnim.Pause();

        _rightlight2D.enabled = false;
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
            if (Mathf.Sign(rb.velocity.x) < 0 && _isGrounded)
            {
                _light2D.enabled = true;

                _sparkAnim.Play();

                _particle.enableEmission = true;

                return;
            }
        }

        _particle.enableEmission = false;

        _sparkAnim.Pause();

        _light2D.enabled = false;

        if (inputDirection < 0)
        {
            if (Mathf.Sign(rb.velocity.x) > 0 && _isGrounded)
            {
                _rightlight2D.enabled = true;

                _rightsparkAnim.Play();

                _rightparticle.enableEmission = true;

                return;
            }
        }

        _rightparticle.enableEmission = false;

        _rightsparkAnim.Pause();

        _rightlight2D.enabled = false;
    }
}

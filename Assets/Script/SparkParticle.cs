using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class SparkParticle : MonoBehaviour
{
    public Rigidbody2D rb;
    private float inputDirection;

    public float _groundCheckDistance = 0.1f;
    public LayerMask _ground;
    private bool _isGrounded;

    private ParticleSystem _particle;

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
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
                _particle.Play();

                return;
            }
        }

        _particle.Pause();

        if (inputDirection < 0)
        {
            if (Mathf.Sign(rb.velocity.x) > 0 && _isGrounded)
            {
                _particle.Play();

                return;
            }
        }

        _particle.Pause();
    }
}

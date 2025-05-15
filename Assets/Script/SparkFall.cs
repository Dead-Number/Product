using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting;
using DG.Tweening;

public class SparkFall : MonoBehaviour
{
    public float _groundCheckDistance = 0.1f;
    public LayerMask _ground;
    private bool _isGrounded;
    private bool _wasGrounded;

    public Light2D light2D;
    private Tween sparkAnim;
    private Tween sparkAnim1;
    public ParticleSystem particle;
    public ParticleSystem particle1;

    private void Awake()
    {
        light2D.enabled = false;

        sparkAnim.Pause();
        sparkAnim1.Pause();

        particle.enableEmission = false;
        particle1.enableEmission = false;
    }

    private void Update()
    {
        Vector2 _playerPos = new Vector2(transform.position.x, transform.position.y);
        _isGrounded = Physics2D.Raycast(_playerPos, Vector2.down, _groundCheckDistance, _ground);

        if (!_wasGrounded && _isGrounded)
        {
            Debug.Log("SPARK");
            light2D.enabled = true;
            sparkAnim.Play();
            sparkAnim1.Play();
            particle.enableEmission = true;
            particle1.enableEmission = true;
            StartCoroutine(SparkStopDelay());
        }

        _wasGrounded = _isGrounded;
    }

    IEnumerator SparkStopDelay()
    {
        yield return new WaitForSeconds(0.1f);

        particle.enableEmission = false;
        particle1.enableEmission = false;

        sparkAnim.Pause();
        sparkAnim1.Pause();

        light2D.enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Vector2 _playerPos = new Vector2(transform.position.x, transform.position.y);
        Gizmos.DrawLine(_playerPos, _playerPos + Vector2.down * _groundCheckDistance);
    }
}

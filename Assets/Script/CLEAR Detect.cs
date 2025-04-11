using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CLEARDetect : MonoBehaviour
{
    public LayerMask _layer;

    public float radius = 2.0f;
    public float _wait = 1.5f;

    public Light2D _light2D1;
    public Light2D _light2D2;
    public Light2D _light2D3;

    public SpriteRenderer _SR1;
    public SpriteRenderer _SR2;
    public SpriteRenderer _SR3;

    public void Start()
    {
        _light2D1.enabled = false;
        _light2D2.enabled = false;
        _light2D3.enabled = false;
    }

    public void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius, _layer);

        foreach (Collider2D hit in hits)
        {
            StartCoroutine(CLEAR_Screen());

            return;
        }
    }

    public IEnumerator CLEAR_Screen()
    {
        _light2D1.enabled = true;
        _SR1.enabled = false;

        yield return new WaitForSeconds(_wait);

        _SR2.enabled = false;
        _light2D2.enabled = true;

        yield return new WaitForSeconds(_wait);

        _light2D3.enabled = true;
        _SR3.enabled = false;

    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Trapdetect : MonoBehaviour
{

    public float posFinal = -7.1f;
    public float posInit = -5.25f;
    public float _duration = 0.5f;

    public Ease AnimType;


    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, Mathf.Infinity, LayerMask.GetMask("Player"));

        if (hit)
        {
            StartCoroutine(TrapCicle());
        }
    }

    IEnumerator TrapCicle()
    {
        Debug.Log("YESSSSS");
        
        transform.DOMoveY(posFinal, _duration)
            .SetEase(AnimType);

        yield return new WaitForSeconds(5);

        transform.DOMoveY(posInit, _duration)
            .SetEase(AnimType);

    }
}

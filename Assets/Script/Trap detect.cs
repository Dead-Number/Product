using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdetect : MonoBehaviour
{

    public LayerMask _layermask;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _layermask);

        if (hit)
        {
            Debug.Log("CRASH");
        }
    }
}

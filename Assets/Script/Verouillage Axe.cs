using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerouillageAxe : MonoBehaviour
{
    private float verrouX;

    void Start()
    {
        verrouX = transform.position.x;
    }

    void Update()
    {
        Vector2 pos = transform.position;
        pos.x = verrouX;
        transform.position = pos;
    }
}

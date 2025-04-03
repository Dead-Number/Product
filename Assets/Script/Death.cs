using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject _player;
    public Rigidbody2D _rb2D;
    public Vector2 _deathDestination;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = _deathDestination;
            _rb2D.velocity = Vector2.zero;

            Debug.Log("YOU DEAD !!!");
        }
    }
}

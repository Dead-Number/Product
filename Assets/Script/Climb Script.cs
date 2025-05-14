using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClimbScript : MonoBehaviour
{
    public SpriteRenderer sptRdr;
    public Sprite Gear;
    public GameObject player;
    public PlayerInput PI;
    public Rigidbody2D Body2D;

    public float destination;
    public float destination1;
    public float moveSpeed;
    public float moveSpeed1;
    public Vector3 rotation;
    public Vector3 rotation1;
    public float rotationDuration;
    public float rotationDuration1;

    public Vector2 interactDestination;

    public float delay;
    public float delay1;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (sptRdr.sprite == Gear)
        {
            if (other.TryGetComponent<PlayerController>(out _))
            {
                Body2D.isKinematic = true;
                Body2D.velocity = Vector2.zero;
                Body2D.constraints = RigidbodyConstraints2D.FreezeRotation;

                PI.actions["Move"].Disable();
                PI.actions["Interract"].Disable();
                PI.actions["Swap"].Disable();
                PI.actions["Menu"].Disable();

                player.transform.position = interactDestination;

                player.transform.DOMoveY(destination, moveSpeed)
                    .SetEase(Ease.Linear)
                    .SetRelative();
                player.transform.DORotate(rotation, rotationDuration)
                    .SetEase(Ease.Linear)
                    .SetRelative();

                StartCoroutine(ClimbDelay());
            }
        }
    }

    public IEnumerator ClimbDelay()
    {
        yield return new WaitForSeconds(delay);

        player.transform.DOMoveX(destination1, moveSpeed1)
            .SetEase(Ease.Linear)
            .SetRelative();

        player.transform.DORotate(rotation1, rotationDuration1)
                    .SetEase(Ease.Linear)
                    .SetRelative();

        yield return new WaitForSeconds(delay1);

        PI.actions["Move"].Enable();
        PI.actions["Interract"].Enable();
        PI.actions["Swap"].Enable();
        PI.actions["Menu"].Enable();

        Body2D.isKinematic = false;
        Body2D.constraints = RigidbodyConstraints2D.None;
    }
}

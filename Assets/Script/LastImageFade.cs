using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LastImageFade : MonoBehaviour
{
    public Image imageBlack;
    public GameObject canvas;
    public GameObject canvas2;
    public GameObject player;
    public TMP_Text End;
    public TMP_Text Credit1;
    public TMP_Text Credit2;
    public TMP_Text Credit3;

    public Vector2 interactDestination;

    public PlayerInput PI;

    public AudioSource audioSource;

    public void Start()
    {
        canvas.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.DOFade(0f, 3f);

            imageBlack.DOFade(1f, 2f);
            canvas.SetActive(true);

            PI.actions["Move"].Disable();
            PI.actions["Interract"].Disable();
            PI.actions["Swap"].Disable();
            PI.actions["Menu"].Disable();

            StartCoroutine(CreditDelay());
        }
    }

    IEnumerator CreditDelay()
    {
        yield return new WaitForSeconds(1f);

        End.DOFade(1f, 2f);

        yield return new WaitForSeconds(10f);

        End.DOFade(0f, 2f);

        yield return new WaitForSeconds(2f);

        Credit1.DOFade(1f, 2f);

        yield return new WaitForSeconds(8f);

        Credit1.DOFade(0f, 1f);

        yield return new WaitForSeconds(1f);

        Credit2.DOFade(1f, 2f);

        yield return new WaitForSeconds(8f);

        Credit2.DOFade(0f, 1f);

        yield return new WaitForSeconds(1f);

        Credit3.DOFade(1f, 2f);

        yield return new WaitForSeconds(8f);
        Credit3.DOFade(0f, 1f);

        player.transform.position = interactDestination;

        yield return new WaitForSeconds(1f);


        PI.actions["Move"].Enable();
        PI.actions["Interract"].Enable();
        PI.actions["Swap"].Enable();
        PI.actions["Menu"].Enable();

        canvas2.SetActive(true);
        canvas.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

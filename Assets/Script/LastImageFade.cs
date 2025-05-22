using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class LastImageFade : MonoBehaviour
{
    public Image imageBlack;
    public GameObject canvas;
    public TMP_Text End;

    public void Start()
    {
        canvas.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            imageBlack.DOFade(1f, 2f);
            canvas.SetActive(true);

            StartCoroutine(CreditDelay());
        }
    }

    IEnumerator CreditDelay()
    {
        yield return new WaitForSeconds(1f);

        End.DOFade(1f, 2f);
    }
}

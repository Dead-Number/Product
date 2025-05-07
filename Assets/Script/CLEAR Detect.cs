using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class CLEARDetect : MonoBehaviour
{
    public DialogueAsset dialogueAsset;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    private int _dialogueLineIndex = -1;

    public LayerMask _layer;
    public PlayerController PC;

    public float radius = 2.0f;
    public float _wait = 1.5f;

    public Light2D _light2D1;
    public Light2D _light2D2;
    public Light2D _light2D3;

    public SpriteRenderer _SR1;
    public SpriteRenderer _SR2;
    public SpriteRenderer _SR3;

    public GameObject player;

    public void Start()
    {
        _light2D1.enabled = false;
        _light2D2.enabled = false;
        _light2D3.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out _))
        {
            StartCoroutine(CLEAR_Screen());

            return;
        }
    }

    public IEnumerator CLEAR_Screen()
    {
        player.GetComponent<PlayerController>().enabled = false;

        _light2D1.enabled = true;
        _SR1.enabled = false;

        yield return new WaitForSeconds(_wait);

        _SR2.enabled = false;
        _light2D2.enabled = true;

        yield return new WaitForSeconds(_wait);

        _light2D3.enabled = true;
        _SR3.enabled = false;

        yield return new WaitForSeconds(_wait);

        DisplayNextDialogueLine();
    }

    private void DisplayNextDialogueLine()
    {
        _dialogueLineIndex++;

        if (_dialogueLineIndex < dialogueAsset.dialogues.Length)
        {
            dialogueBox.SetActive(true);

            dialogueText.text = dialogueAsset.dialogues[_dialogueLineIndex];
        }

        else
        {
            dialogueBox.SetActive(false);
        }

    }

    public void OnNextLine()
    {
        _dialogueLineIndex++;

        if (_dialogueLineIndex < dialogueAsset.dialogues.Length)
        {
            dialogueBox.SetActive(true);

            dialogueText.text = dialogueAsset.dialogues[_dialogueLineIndex];
        }

        else
        {
            dialogueBox.SetActive(false);
        }
    }
}

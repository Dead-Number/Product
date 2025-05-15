using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;
using UnityEngine.Events;

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
    public PlayerInput PI;

    public bool BoolCLEAR;

    public void Start()
    {
        _light2D1.enabled = false;
        _light2D2.enabled = false;
        _light2D3.enabled = false;

        PI.actions["NextLine"].Disable();
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
        PI.actions["Move"].Disable();
        PI.actions["Interract"].Disable();
        PI.actions["Swap"].Disable();
        PI.actions["Menu"].Disable();

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
        PI.actions["NextLine"].Enable();
    }

    public void DisplayNextDialogueLine()
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

            PI.actions["NextLine"].Disable();

            PI.actions["Move"].Enable();
            PI.actions["Interract"].Enable();
            PI.actions["Swap"].Enable();
            PI.actions["Menu"].Enable();

            GetComponent<BoxCollider2D>().enabled = false;

            BoolCLEAR = true;
        }
    }
}

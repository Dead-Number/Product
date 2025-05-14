using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;

public class CLEARDetect2 : MonoBehaviour
{
    public DialogueAsset dialogueAsset;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    private int _dialogueLineIndex = -1;

    public LayerMask layer;
    public PlayerController PC;

    public float radius = 2.0f;
    public float wait = 1.5f;

    public Light2D light2D1;
    public Light2D light2D2;
    public Light2D light2D3;
    public Light2D light2D4;
    public Light2D light2D5;
    public Light2D light2D6;

    public SpriteRenderer SR1;
    public SpriteRenderer SR2;
    public SpriteRenderer SR3;
    public SpriteRenderer SR4;
    public SpriteRenderer SR5;
    public SpriteRenderer SR6;

    public GameObject player;
    public PlayerInput PI;

    public void Start()
    {
        light2D1.enabled = false;
        light2D2.enabled = false;
        light2D3.enabled = false;
        light2D4.enabled = false;
        light2D5.enabled = false;
        light2D6.enabled = false;

        PI.actions["NextLine"].Disable();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out _))
        {
            StartCoroutine(CLEAR_Screen2());

            return;
        }
    }

    public IEnumerator CLEAR_Screen2()
    {
        PI.actions["Move"].Disable();
        PI.actions["Interract"].Disable();
        PI.actions["Swap"].Disable();
        PI.actions["Menu"].Disable();

        light2D1.enabled = true;
        SR1.enabled = false;

        yield return new WaitForSeconds(wait);

        SR2.enabled = false;
        light2D2.enabled = true;

        yield return new WaitForSeconds(wait);

        light2D3.enabled = true;
        SR3.enabled = false;

        yield return new WaitForSeconds(wait);

        light2D4.enabled = true;
        SR4.enabled = false;

        yield return new WaitForSeconds(wait);

        light2D5.enabled = true;
        SR5.enabled = false;

        yield return new WaitForSeconds(wait);

        light2D6.enabled = true;
        SR6.enabled = false;

        DisplayNextDialogueLine2();
        PI.actions["NextLine"].Enable();
    }

    public void DisplayNextDialogueLine2()
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
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextChange : MonoBehaviour
{
    public TMP_Text _text;
    public string _newtext = "Press 'Y'";
    public string _basetext = "Press 'E'";

    public float _duration = 0.5f;
    public float _wait = 3f;



    public void Start()
    {
        StartCoroutine(TextSwap());
    }

    public IEnumerator TextSwap()
    {
        while (true)
        {
            _text.DOFade(0f, _duration).WaitForCompletion();
                    _text.text = _newtext;
                    _text.DOFade(1f, _duration);

            yield return new WaitForSeconds(_duration + _wait);

            _text.DOFade(0f, _duration).WaitForCompletion();
                    _text.text = _basetext;
                    _text.DOFade(1f, _duration);

            yield return new WaitForSeconds(_duration + _wait);


        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionTextManager : MonoBehaviour
{
    public enum State { TYPING, CHECKING, CHANGING}

    [SerializeField] private GameObject _introductionTextCanvas;
    [SerializeField] private TextMeshProUGUI _introductionText;
    [SerializeField] private GameObject _startButtonObject;
    [SerializeField] private Button _startButton;

    [TextArea(4,7)]
    [SerializeField] private string[] _textToWrite;
    [SerializeField] private int _currentSentenceIndex;
    [SerializeField] private float _typingSpeed;
    [SerializeField] private float _timeBetweenNextSentences;

    [SerializeField] private State _state = State.CHECKING;
    private void Start()
    {

        SoundManager.Instance.IsMusicPlaying = false;

        _introductionText.text = string.Empty;

        _startButton.onClick.AddListener(() =>
        {
            _introductionTextCanvas.SetActive(false);
            DialogueManager.Instance.SetIsPlayingDialogue(true);
        });
    }

    private void Update()
    {
        if (_state == State.CHANGING)
        {
            if (_currentSentenceIndex < _textToWrite.Length - 1)
            {
                _currentSentenceIndex++;
                _introductionText.text = string.Empty;
            }
            else
            {
                _startButtonObject.SetActive(true);
                return;
            }
        }

        if (_state != State.TYPING)
        {
            StartCoroutine(WritingRoutine());
        }
    }

    private IEnumerator WritingRoutine()
    {
        _state = State.TYPING;
        for (int i = 0; i < _textToWrite[_currentSentenceIndex].ToCharArray().Length; i++)
        {
            char c = _textToWrite[_currentSentenceIndex].ToCharArray()[i];
            _introductionText.text += c;
            yield return new WaitForSeconds(_typingSpeed);
        }
        yield return new WaitForSeconds(_timeBetweenNextSentences);
        _state = State.CHANGING;


       
    }
}

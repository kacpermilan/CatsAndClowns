using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreenDialogue : MonoBehaviour
{
    [Header("Typing Parameters")]
    [TextArea(2, 4)]
    [SerializeField] private string[] _dialogueLines;
    [SerializeField] private int _dialogueLineIndex;
    [SerializeField] private float _typingSpeed;

    [Header("References")]
    [SerializeField] private GameObject _nextButtonObject;
    [SerializeField] private Button _nextButton;
    [SerializeField] private TextMeshProUGUI _dialogueText;

    [Header("Portraits")]
    [SerializeField] private GameObject _mnichPortrait;
    [SerializeField] private GameObject _satanPortrait;
    [SerializeField] private bool _isPlayerTalking;

    private void Start()
    {
        _dialogueText.text = string.Empty;
        _nextButton.onClick.AddListener(() =>
        {
            if (_dialogueLineIndex >= _dialogueLines.Length - 1)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                _isPlayerTalking = !_isPlayerTalking;
                _dialogueText.text = string.Empty;
                _dialogueLineIndex++;
                StartCoroutine(TypingRoutine());
                _nextButtonObject.SetActive(false);
            }
        });

        StartCoroutine(TypingRoutine());
    }
    private void Update()
    {
        DisplayPortrait();
    }

    private void DisplayPortrait()
    {
        if (_isPlayerTalking)
        {
            _mnichPortrait.SetActive(true);
            _satanPortrait.SetActive(false);
        }
        else
        {
            _mnichPortrait.SetActive(false);
            _satanPortrait.SetActive(true);
        }
    }

    private IEnumerator TypingRoutine()
    {
        for (int i = 0; i < _dialogueLines[_dialogueLineIndex].ToCharArray().Length; i++)
        {
            char c = _dialogueLines[_dialogueLineIndex].ToCharArray()[i];
            _dialogueText.text += c;
            yield return new WaitForSeconds(_typingSpeed);
        }
        _nextButtonObject?.SetActive(true);

    }
}

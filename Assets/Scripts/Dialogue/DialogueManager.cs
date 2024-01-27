using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Typing Parameters")]
    [TextArea(2,4)]
    [SerializeField] private string[] _dialogueLines;
    [SerializeField] private int _dialogueLineIndex;
    [SerializeField] private float _typingSpeed;

    [Header("References")]
    [SerializeField] private GameObject _nextButtonObject;
    [SerializeField] private Button _nextButton;
    [SerializeField] private TextMeshProUGUI _dialogueText;

    private void Start()
    {
        _dialogueText.text = string.Empty;
        _nextButton.onClick.AddListener(() =>
        {
            if (_dialogueLineIndex >= _dialogueLines.Length -1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                _dialogueText.text = string.Empty;
                _dialogueLineIndex++;
                StartCoroutine(TypingRoutine());
                _nextButtonObject.SetActive(false);
            }
        });

        StartCoroutine(TypingRoutine());
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

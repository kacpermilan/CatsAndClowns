using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuWindow;
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private GameObject _creditsWindow;

    [SerializeField] private Button _startBttn;
    [SerializeField] private Button _settingsBttn;
    [SerializeField] private Button _creditsBttn;
    [SerializeField] private Button _settingsBackBttn;
    [SerializeField] private Button _creditsBackBttn;
    [SerializeField] private Button _quitBttn;

    private void Start()
    {
        _startBttn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });

        _settingsBttn.onClick.AddListener(() =>
        {
            _mainMenuWindow.SetActive(false);
            _settingsWindow.SetActive(true);
        });

        _creditsBttn.onClick.AddListener(() =>
        {
            _mainMenuWindow.SetActive(false);
            _creditsWindow.SetActive(true);
        });

        _settingsBackBttn.onClick.AddListener(() =>
        {
            _settingsWindow.SetActive(false);
            _mainMenuWindow.SetActive(true);
        });
        _creditsBackBttn.onClick.AddListener(() =>
        {
            _creditsWindow.SetActive(false);
            _mainMenuWindow.SetActive(true);
        });
        _quitBttn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Image _playerHealthFill;
    [SerializeField] private float _healthUIDecreaseDisplay;
    private void Update()
    {
        // _playerHealthFill.fillAmount = PlayerBoss.Instance.GetHealthNormalized();
        _playerHealthFill.fillAmount = Mathf.Lerp(_playerHealthFill.fillAmount, PlayerBoss.Instance.GetHealthNormalized(), _healthUIDecreaseDisplay * Time.deltaTime);
    }

}

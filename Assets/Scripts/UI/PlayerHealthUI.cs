using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Image _playerHealthFill;

    private void Update()
    {
        _playerHealthFill.fillAmount = PlayerBoss.Instance.GetHealthNormalized();
      
    }

}

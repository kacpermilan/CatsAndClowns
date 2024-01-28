using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Image _enemyHealthFill;
    [SerializeField] private float _healthDecreaseUIDisplaySpeed;

    private void Update()
    {
        
        _enemyHealthFill.fillAmount = Mathf.Lerp(_enemyHealthFill.fillAmount, EnemyBoss.Instance.GetHealthNormalized(), _healthDecreaseUIDisplaySpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Image _enemyHealthFill;

    private void Update()
    {
        _enemyHealthFill.fillAmount = EnemyBoss.Instance.GetHealthNormalized();
    }

}

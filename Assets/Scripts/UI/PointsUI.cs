using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointsText;

    private void Start()
    {
        PointsManager.Instance.OnPointsChanged += PointsManager_OnPointsChanged;
        _pointsText.text = "Points: " + PointsManager.Instance.GetPointsLeftInCurrentTurn().ToString();
    }

    private void PointsManager_OnPointsChanged(object sender, PointsManager.OnPointsChangedEventArgs e)
    {
        _pointsText.text = "Points: " + e.pointsLeftInCurrentTurn.ToString();
    }
}

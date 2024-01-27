using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resourcesText;

    private void Start()
    {
        PointsManager.Instance.OnResourcesChanged += PointsBank_OnResourcesChanged;
        _resourcesText.text = "Resources: " + PointsManager.Instance.GetCurrentResources().ToString();
    }

    private void PointsBank_OnResourcesChanged(object sender, PointsManager.OnResourcesChangedEventArgs e)
    {
        _resourcesText.text = "Resources: " + e.currentResources.ToString();
    }
}

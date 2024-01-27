using TMPro;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resourcesText;

    private void Start()
    {
        ResourceManager.Instance.OnResourcesChanged += PointsBank_OnResourcesChanged;
        _resourcesText.text = "Resources: " + ResourceManager.Instance.GetCurrentResources();
    }

    private void PointsBank_OnResourcesChanged(object sender, ResourceManager.OnResourcesChangedEventArgs e)
    {
        _resourcesText.text = "Resources: " + e.CurrentResources;
    }
}

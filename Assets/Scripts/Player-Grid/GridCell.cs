using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] private bool _isPlaceable;

    public void OnMouseClick()
    {
        Debug.Log("Cell " + gameObject.name + "clicked");
    }
    
   
}

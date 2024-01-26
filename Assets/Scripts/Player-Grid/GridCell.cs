using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] private bool _isPlaceable;

    public void OnMouseClick()
    {
       if (_isPlaceable)
        {
            Debug.Log("Entity Placed");
            _isPlaceable = false;
        }
    }
    
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionDependantObj : MonoBehaviour
{
    protected virtual void Init()
    {
        DimensionManager.Instance.OnDimensionChange += HandleDimensionChange;
    }

    protected virtual void HandleDimensionChange(int _dimensionState)
    {
        Debug.Log("Changed to state: " + (_dimensionState == 0 ? "Real" : "Dream"));
    }
}

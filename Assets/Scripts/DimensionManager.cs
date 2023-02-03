using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DimensionManager : MonoBehaviour
{
    public static DimensionManager Instance;

    [SerializeField] EventManager _eventManager;

    public UnityEvent<int> OnDimensionChange;

    int _dimension;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeDimension()
    {
        _dimension = 1 - _dimension;
        OnDimensionChange?.Invoke(_dimension);
        Debug.Log("Current dimension: " + (_dimension == 0 ? "Real" : "Dream"));
    }
}

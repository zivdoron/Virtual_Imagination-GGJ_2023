using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DimensionManager : MonoBehaviour
{
    [SerializeField] EventManager _eventManager;
    [SerializeField] UnityEvent _onDimensionChange;

    // Start is called before the first frame update
    void Start()
    {
        _eventManager.OnChangeDimension += () => _onDimensionChange?.Invoke();
    }
}

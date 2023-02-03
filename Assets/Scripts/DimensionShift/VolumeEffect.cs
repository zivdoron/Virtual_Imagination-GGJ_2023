using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeEffect : DimensionDependantObj
{
    Volume _dreamVolume;

    // Start is called before the first frame update
    void Start()
    {
        Init();   
    }

    protected override void Init()
    {
        base.Init();
        _dreamVolume = GetComponent<Volume>();
    }

    protected override void HandleDimensionChange(int _dimensionState)
    {
        base.HandleDimensionChange(_dimensionState);
        _dreamVolume.weight = _dimensionState;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightEffect : DimensionDependantObj
{
    Light2D _light;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        _light = GetComponent<Light2D>();
    }

    protected override void HandleDimensionChange(int _dimensionState)
    {
        base.HandleDimensionChange(_dimensionState);
        _light.intensity = _dimensionState == 0 ? 1 : 0.5f;
    }
}

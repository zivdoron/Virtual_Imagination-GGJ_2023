using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeEffect : DimensionDependantObj
{
    [SerializeField] float maxTimeInDreamWorld = 15f;

    float _timeCounter;
    delegate void VolumeEffectAction();
    Volume _dreamVolume;
    Vignette _vg;

    VolumeEffectAction _dreamEffect;

    // Start is called before the first frame update
    void Start()
    {
        Init();   
    }

    protected override void Init()
    {
        base.Init();
        _dreamVolume = GetComponent<Volume>();
        _dreamVolume.profile.TryGet(out _vg);
    }

    protected override void HandleDimensionChange(int _dimensionState)
    {
        base.HandleDimensionChange(_dimensionState);
        _dreamVolume.weight = _dimensionState;
        if (_dimensionState == 1)
        {
            _timeCounter = _vg.intensity.value = 0;
            _dreamEffect = DecreaseTimer;
        }
    }

    private void Update()
    {
        _dreamEffect?.Invoke();
    }

    void DecreaseTimer()
    {
        if (_timeCounter < maxTimeInDreamWorld)
        {
            _timeCounter += Time.deltaTime;
            _vg.intensity.value += Time.deltaTime / maxTimeInDreamWorld;
        }
        else
        {
            Debug.Log("Player has run out of time...");
            _dreamEffect = null;
        }
    }
}

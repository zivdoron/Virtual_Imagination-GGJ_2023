using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessVolume : MonoBehaviour
{
    [SerializeField] EventManager _eventManager;

    Volume _postProcessingVolume;

    // Start is called before the first frame update
    void Start()
    {
        _postProcessingVolume = GetComponent<Volume>();
        _eventManager.OnChangeDimension += SwapVolume;
    }

    void SwapVolume()
    {
        float currentWeight = _postProcessingVolume.weight;
        _postProcessingVolume.weight = 1 - currentWeight;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    [SerializeField] EventManager _eventManager;
    int _currentScale = 0;
    float[] _sizes = new float[]
    {
        1f,
        0.6f,
        0.3f,
        0.1f
    };

    // Start is called before the first frame update
    void Start()
    {
        _eventManager.OnAbilityPressed += CycleSize;
    }

    // Update is called once per frame
    void CycleSize()
    {
        _currentScale = (_currentScale + 1) % (CharacterAbilities.instance.Strength + 1);
        transform.localScale = Vector3.one * _sizes[_currentScale];
    }
}

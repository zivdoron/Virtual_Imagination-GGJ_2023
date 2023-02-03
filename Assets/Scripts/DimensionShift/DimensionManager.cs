using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DimensionManager : MonoBehaviour
{
    public static DimensionManager Instance;

    [SerializeField] EventManager _eventManager;
    [SerializeField] Material _dreamGateMaterial;

    public System.Action<int> OnDimensionChange;

    int _dimension;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _eventManager.OnObtainDimentionTravel += EnableAllDreamGates;
        _dreamGateMaterial.SetFloat("_BlendAmount", 0f);
    }

    void EnableAllDreamGates()
    {
        StartCoroutine(DreamGatesAnimation());
    }

    IEnumerator DreamGatesAnimation()
    {
        float amount = 0f;
        while(amount < 1f)
        {
            amount += Time.deltaTime;
            _dreamGateMaterial.SetFloat("_BlendAmount", amount);
            yield return new WaitForEndOfFrame();
        }
    }

    public void ChangeDimension()
    {
        _dimension = 1 - _dimension;
        OnDimensionChange?.Invoke(_dimension);
        Debug.Log("Current dimension: " + (_dimension == 0 ? "Real" : "Dream"));
    }
}

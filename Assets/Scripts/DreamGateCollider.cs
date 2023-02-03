using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamGateCollider : MonoBehaviour
{
    [SerializeField] EventManager _eventManager;

    Collider2D _gateCollider;

    // Start is called before the first frame update
    void Start()
    {
        _gateCollider = GetComponent<Collider2D>();

        DimensionManager.Instance.OnDimensionChange += dimensionState => _gateCollider.enabled = dimensionState == 0;
    }
}

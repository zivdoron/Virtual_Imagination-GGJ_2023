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

        _eventManager.OnChangeDimension += () =>
        {
            _gateCollider.enabled = !_gateCollider.enabled;
            Debug.Log("Gate collider enabled: " + _gateCollider.enabled);
        };
    }
}

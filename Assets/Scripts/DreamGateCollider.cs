using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamGateCollider : MonoBehaviour
{
    [SerializeField] EventManager _eventManager;
    [SerializeField] Sprite _enabledSprite;
    [SerializeField] ParticleSystem _particleEffect;

    SpriteRenderer _gateRenderer;
    Collider2D _gateCollider;

    // Start is called before the first frame update
    void Start()
    {
        _gateCollider = GetComponent<Collider2D>();
        _gateRenderer = GetComponent<SpriteRenderer>();

        DimensionManager.Instance.OnDimensionChange += dimensionState => _gateCollider.enabled = dimensionState == 0;
        _eventManager.OnObtainDimentionTravel += EnableGateFunctions;
    }

    void EnableGateFunctions()
    {
        _particleEffect.Play();
    }
}

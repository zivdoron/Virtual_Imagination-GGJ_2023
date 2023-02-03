using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public UnityEvent<bool> OnToggle;

    [SerializeField] EventManager _eventManager;

    SpriteRenderer _switchRenderer;
    bool _isOn = false, _playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        _switchRenderer = GetComponentInChildren<SpriteRenderer>();

        _switchRenderer.color = Color.red;

        _eventManager.OnInteractPressed += () =>
        {
            if (_playerInRange)
            {
                ToggleSwitch();
            }
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInRange = false;
        }
    }

    void ToggleSwitch()
    {
        _isOn = !_isOn;
        _switchRenderer.color = _isOn ? Color.green : Color.red;

        Vector3 _theScale = transform.localScale;
        _theScale.y = _isOn ? -1 : 1;
        transform.localScale = _theScale;

        OnToggle?.Invoke(_isOn);
    }
}

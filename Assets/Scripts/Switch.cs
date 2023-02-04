using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public UnityEvent OnToggle;

    [SerializeField] EventManager _eventManager;

    bool _isOn = false, _playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
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
        Vector3 _theScale = transform.localScale;
        _theScale.y = _isOn ? -1 : 1;
        transform.localScale = _theScale;

        OnToggle?.Invoke();
    }
}

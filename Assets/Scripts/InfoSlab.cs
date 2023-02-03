using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InfoSlab : MonoBehaviour
{
    [SerializeField] EventManager _eventManager;

    [SerializeField][TextArea(3,10)]string _slabText;
    [SerializeField] TextMeshProUGUI _uiText;
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] bool triggersEventOnEPress;

    public UnityEvent OnTriggerEvent;

    public bool reading;

    private void Start()
    {
        _uiText.text = _slabText;
        if (triggersEventOnEPress)
        {
            _eventManager.OnInteractPressed += () =>
            {
                if (!reading) return;
                OnTriggerEvent?.Invoke();
                Destroy(gameObject);
            };
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //display slab text
            _canvasGroup.alpha = 1;

            reading = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //hide slab text
            _canvasGroup.alpha = 0;

            reading = false;
        }
    }
}

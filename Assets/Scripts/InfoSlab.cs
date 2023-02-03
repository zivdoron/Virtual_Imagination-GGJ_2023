using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoSlab : MonoBehaviour
{
    [SerializeField][TextArea(3,10)]string _slabText;
    [SerializeField] TextMeshProUGUI _uiText;
    [SerializeField] CanvasGroup _canvasGroup;

    private void Start()
    {
        _uiText.text = _slabText;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //display slab text
            _canvasGroup.alpha = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //hide slab text
            _canvasGroup.alpha = 0;
        }
    }
}

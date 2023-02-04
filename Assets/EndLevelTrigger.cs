using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent OnPlayerTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPlayerTrigger?.Invoke();
        }
    }
}

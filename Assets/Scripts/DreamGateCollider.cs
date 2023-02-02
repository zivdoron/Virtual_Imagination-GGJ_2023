using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamGateCollider : MonoBehaviour
{
    [SerializeField] EventManager _eventManager;

    Collider2D _gateCollider;
    Vector2 _entryDirection;

    // Start is called before the first frame update
    void Start()
    {
        _gateCollider = GetComponent<Collider2D>();

        _eventManager.OnObtainDimentionTravel += () =>
        {
            _gateCollider.isTrigger = true;
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DimensionManager.Instance.ChangeDimension();
            _entryDirection = transform.InverseTransformDirection(
                PlayerController.Instance.transform.position - transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        Vector2 _exitDirection = transform.InverseTransformDirection(
                PlayerController.Instance.transform.position - transform.position);
        if (Mathf.Sign(_exitDirection.y) == Mathf.Sign(_entryDirection.y))
        {
            DimensionManager.Instance.ChangeDimension();
        }
    }
}

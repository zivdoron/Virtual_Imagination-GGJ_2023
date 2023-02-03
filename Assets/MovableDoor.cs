using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

enum OpenType
{
    Move,
    Rotate
}
public class MovableDoor : MonoBehaviour
{
    delegate void DoorOpenSequence();

    [SerializeField] Transform _openTransform;
    [SerializeField] Transform _doorParent;
    [SerializeField]
    [Min(1f)] float _doorSpeed = 3f;
    [SerializeField] float _endRotationValue = 90;
    [SerializeField] OpenType _doorOpenType;

    Vector3 _openPosition;
    Vector3 _closePosition;

    bool _isOpen;

    DoorOpenSequence _openSequence;

    // Start is called before the first frame update
    void Start()
    {
        switch (_doorOpenType)
        {
            case OpenType.Move:
                _openPosition = _openTransform.position;
                _closePosition = _doorParent.position;
                _openSequence = MoveDoor;
                break;
            case OpenType.Rotate:
                _openSequence = RotateDoor;
                break;
            default:
                break;
        }

        
    }

    public void ToggleDoorOpen()
    {
        _isOpen = !_isOpen;
        _openSequence?.Invoke();
    }

    void MoveDoor()
    {
        Vector3 _endPosition = _isOpen ? _openPosition : _closePosition;
        Move(_endPosition);
    }
    void Move(Vector3 dest)
    {
        StopAllCoroutines();
        StartCoroutine(MoveDoorCoroutine(dest));
    }
    public void OpenDoor()
    {
        if(_doorOpenType == OpenType.Move)
        {
            Move(_openPosition);
            _isOpen = true;
        }
        if (_doorOpenType == OpenType.Rotate)
        {
            Rotate(_openPosition);
            _isOpen= true;
        }
    }
    public void CloseDoor()
    {
        if (_doorOpenType == OpenType.Move)
        {
            Move(_closePosition);
            _isOpen = false;
        }
        if (_doorOpenType == OpenType.Rotate)
        {
            Rotate(_closePosition);
            _isOpen = false;
        }
    }

    void RotateDoor()
    {
        Vector3 _endRotation = _isOpen ? Vector3.forward * _endRotationValue : Vector3.zero;
        Rotate(_endRotation);
    }

    private void Rotate(Vector3 _endRotation)
    {
        StopAllCoroutines();
        StartCoroutine(RotateDoorCoroutine(_endRotation));
    }



    IEnumerator MoveDoorCoroutine(Vector3 _endPosition)
    {
        while (Vector3.SqrMagnitude(_doorParent.position - _endPosition) > 0.1f)
        {
            _doorParent.position = Vector3.Lerp(_doorParent.position, _endPosition, _doorSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();

        }
    }

    IEnumerator RotateDoorCoroutine(Vector3 _endRotationVector)
    {
        Quaternion _endRotation = Quaternion.Euler(_endRotationVector);
        while (Vector3.SqrMagnitude(_doorParent.localRotation.eulerAngles - _endRotationVector) > 0.1f)
        {
            _doorParent.localRotation = Quaternion.Lerp(_doorParent.localRotation, _endRotation, _doorSpeed * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }
}

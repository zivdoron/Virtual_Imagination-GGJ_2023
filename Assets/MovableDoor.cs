using System;
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
    [SerializeField] bool _hasPower = true;

    Vector3 _openPosition;
    Vector3 _closePosition;

    bool _isOpen;

    DoorOpenSequence _openSequence;
    List<DoorOpenSequence> _openSequenceList = new List<DoorOpenSequence>();

    // Start is called before the first frame update
    void Start()
    {
        switch (_doorOpenType)
        {
            case OpenType.Move:
                _openPosition = _openTransform.position;
                _closePosition = _doorParent.position;
                _openSequence = Move;
                break;
            case OpenType.Rotate:
                _openSequence = Rotate;
                break;
            default:
                break;
        }

        
    }

    public void ToggleDoorOpen()
    {
        if (!_hasPower)
        {
            _openSequenceList.Add(_isOpen? CloseDoor : OpenDoor);
            return;
        }
        _isOpen = !_isOpen;
        _openSequence?.Invoke();
    }

    void Move()
    {
        Vector3 _endPosition = _isOpen ? _openPosition : _closePosition;
        StopAllCoroutines();
        StartCoroutine(MoveDoorCoroutine(_endPosition));
    }
    public void OpenDoor()
    {
        if (!_hasPower)
        {
            _openSequenceList.Add(OpenDoor);
            return;
        }
        if (_doorOpenType == OpenType.Move)
        {
            _isOpen = true;
            Move();
        }
        if (_doorOpenType == OpenType.Rotate)
        {
            _isOpen= true;
            Rotate();
        }
    }
    public void CloseDoor()
    {
        if (!_hasPower)
        {
            _openSequenceList.Add(CloseDoor);
            return;
        }
        Debug.Log("Close Called!");
        if (_doorOpenType == OpenType.Move)
        {
            _isOpen = false;
            Move();
        }
        if (_doorOpenType == OpenType.Rotate)
        {
            _isOpen = false;
            Rotate();
        }
    }

    private void Rotate()
    {
        Debug.Log(_isOpen);
        Vector3 _endRotation = _isOpen ? Vector3.forward * _endRotationValue : Vector3.zero;
        StopAllCoroutines();
        StartCoroutine(RotateDoorCoroutine(_endRotation));
    }



    IEnumerator MoveDoorCoroutine(Vector3 _endPosition)
    {
        while (Vector3.SqrMagnitude(_doorParent.position - _endPosition) > Mathf.Epsilon)
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

    public void SetPowerEnabled(bool value)
    {
        _hasPower = value;
        if (!value) return;
        Debug.Log("Checking list... " + _openSequenceList.Count + " waiting operation(s)!");
        _openSequenceList[_openSequenceList.Count - 1].Invoke();
        _openSequenceList.Clear();
    }
}

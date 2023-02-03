using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElectricPuzzleBase : MonoBehaviour
{
    [SerializeField] Transform transformPointsParent;
    [SerializeField] LineRenderer _lineRendererTemplate;
    [SerializeField]
    [Tooltip("Write the index at which the break happens. Example: [3] will yield a circuit break between points 3 and 4")] 
    int _breakAtPoint;
    [SerializeField] ParticleSystem _sparksParticles;

    bool _isBroken;
    Transform[] _points;
    LineRenderer _lineStart;
    LineRenderer _lineEnd;

    public UnityEvent<bool> OnCircuitToggle;

    // Start is called before the first frame update
    void Start()
    {
        SetupWirePoints();
        SetupLineRenderers();
    }

    void SetupLineRenderers()
    {
        _lineStart = Instantiate(_lineRendererTemplate, transform);
        _lineEnd = Instantiate(_lineRendererTemplate, transform);

        _lineStart.positionCount = _breakAtPoint + 2;
        for (int i = 0; i < _breakAtPoint + 1; i++)
        {
            _lineStart.SetPosition(i, transform.InverseTransformPoint(_points[i].transform.position));
        }

        DrawBrokenPath();

        _lineEnd.positionCount = _points.Length - (_breakAtPoint + 1);
        for (int i = _breakAtPoint + 1; i < _points.Length; i++)
        {
            _lineEnd.SetPosition(i - (_breakAtPoint + 1), transform.InverseTransformPoint(_points[i].transform.position));
        }

        _sparksParticles.transform.position = _points[_breakAtPoint + 1].transform.position;
    }

    void DrawBrokenPath()
    {
        Vector2 directionToNextPoint =
            transform.InverseTransformPoint(_points[_breakAtPoint + 1].transform.position)
            - transform.InverseTransformPoint(_points[_breakAtPoint].transform.position);
        Vector3 _brokenDirection = Quaternion.Euler(Vector3.forward * 10f) * directionToNextPoint;
        _lineStart.SetPosition(_breakAtPoint + 1, 
            transform.InverseTransformPoint(_points[_breakAtPoint].transform.position) + _brokenDirection);
        _lineStart.startColor = _lineStart.endColor = _lineEnd.startColor = _lineEnd.endColor = Color.red;
        _isBroken = true;
    }

    private void SetupWirePoints()
    {
        _points = new Transform[transformPointsParent.childCount];
        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = transformPointsParent.GetChild(i).transform;
        }
    }

    public void ToggleBroken()
    {
        if (!_isBroken)
        {
            DrawBrokenPath();
        }
        else
        {
            DrawFixedPath();
        }
        OnCircuitToggle?.Invoke(!_isBroken);
    }

    void DrawFixedPath()
    {
        _lineStart.SetPosition(_breakAtPoint + 1, 
            transform.InverseTransformPoint(_points[_breakAtPoint + 1].transform.position));
        _lineStart.startColor = _lineStart.endColor = _lineEnd.startColor = _lineEnd.endColor = Color.green;
        
        _sparksParticles.Play();
        _isBroken = false;
    }
}

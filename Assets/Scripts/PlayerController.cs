using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] InputReceiver _inputReceiver;

    [SerializeField][Min(1f)] float _moveSpeed = 3f;

    Rigidbody2D _playerRB;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _inputReceiver.Init();

        _playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 rawInput = _inputReceiver.DirectionInput;
        rawInput = Vector2.ClampMagnitude(rawInput, 1);
        _playerRB.velocity = rawInput * _moveSpeed;
    }
}

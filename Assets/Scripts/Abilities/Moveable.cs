using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    [SerializeField] int _requiredStrength;
    [SerializeField] Rigidbody2D _rb;

    private void Start()
    {
        MoveablesManager.Register(this);
    }
    public void Unlock()
    {
        if(CharacterAbilities.instance.Strength > _requiredStrength)
        {
            _rb.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            _rb.bodyType = RigidbodyType2D.Static;
        }
    }
}

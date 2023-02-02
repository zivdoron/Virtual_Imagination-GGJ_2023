using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    public static CharacterAbilities instance;

    [SerializeField] int strength;
    public int Strength { get => strength; }
    private void Start()
    {
        instance = this;
    }
}

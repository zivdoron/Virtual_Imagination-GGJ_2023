using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    public static CharacterAbilities instance;

    [SerializeField] int strength;
    public int Strength { get => strength; }

    Breakable currBreakable;
    private void Start()
    {
        instance = this;
    }

    public void Strengthen(int addition)
    {
        strength += addition;
    }

    public void AssignBreakable(Breakable breakable)
    {
        currBreakable = breakable;
    }
    public void UnassignBreakable(Breakable breakable)
    {
        if(currBreakable == breakable)
        {
            currBreakable = null;
        }
    }
    public void Break()
    {
        if(currBreakable != null)
        {
            Destroy(currBreakable.gameObject);
            currBreakable = null;
        }
    }
}

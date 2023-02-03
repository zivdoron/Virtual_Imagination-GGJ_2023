using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class MoveablesManager
{
    public static int strength;
    static List<Moveable> moveables = new List<Moveable>();

    public static bool Register(Moveable moveable)
    {
        if (moveables.Exists(m => m == moveable))
        {
            Debug.Log("the moveable already registered, aborting registration");
            return false;
        }
        else
        {
            moveables.Add(moveable);
            return true;
        }
    }
    public static void Unlock()
    {
        for (int i = 0; i < moveables.Count; i++)
        {
            moveables[i].Unlock();
        }
    }
}

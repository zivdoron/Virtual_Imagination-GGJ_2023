using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == PlayerController.Instance.gameObject)
        {
            CharacterAbilities.instance.AssignBreakable(this);
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {        
        if (collision.gameObject == PlayerController.Instance.gameObject)
        {
            CharacterAbilities.instance.UnassignBreakable(this);
        }
    }
}

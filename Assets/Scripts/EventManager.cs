using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event Manager", menuName = "Managers/Event Manager")]
public class EventManager : ScriptableObject
{
    public System.Action OnObtainDimentionTravel;
    public System.Action OnInteractPressed;
    public System.Action OnAbilityPressed;

    public void RegisterDimensionTravelObtained()
    {
        OnObtainDimentionTravel?.Invoke();
    }
}

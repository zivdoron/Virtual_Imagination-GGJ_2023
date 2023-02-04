using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event Manager", menuName = "Managers/Event Manager")]
public class EventManager : ScriptableObject
{
    public System.Action OnObtainDimentionTravel;
    public System.Action OnObtainPushAbility;
    public System.Action OnInteractPressed;
    public System.Action OnAbilityPressed;
    public System.Action OnScreenTransitionCalled;
    public System.Action OnReadyToSceneTransition;

    public void RegisterDimensionTravelObtained()
    {
        OnObtainDimentionTravel?.Invoke();
    }

    public void RegisterObjectPushObtained()
    {
        OnObtainPushAbility?.Invoke();
    }

    public void CallScreenTransition()
    {
        OnScreenTransitionCalled?.Invoke();
    }
}

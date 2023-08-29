using System;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    public static Action OnShot;
    
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        OnShot?.Invoke();
    }
}
using System;
using UnityEngine;

public class LifeEventEmitter : MonoBehaviour
{
    public static event Action OnTakeDamage;
    public static event Action OnHeal;

    public void OnPressTakeDamage()
    {
        OnTakeDamage?.Invoke();
    }
    public void OnPressHeal()
    {
        OnHeal.Invoke();
    }

}

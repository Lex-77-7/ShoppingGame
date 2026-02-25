using System;
using UnityEngine;

public class LifeEventEmitter : MonoBehaviour
{
    public static event Action OnTakeDamage;

    public void OnPressTakeDamage()
    {
        OnTakeDamage?.Invoke();
    }
}

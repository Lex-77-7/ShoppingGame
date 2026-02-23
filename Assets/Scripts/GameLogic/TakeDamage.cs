using System;
using UnityEngine;

public class TakeDamageButton : MonoBehaviour
{
    public static event Action OnTakeDamage;

    public void OnPressTakeDamage()
    {
        OnTakeDamage?.Invoke();
    }
}

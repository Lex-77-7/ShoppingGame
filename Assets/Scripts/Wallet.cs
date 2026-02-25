using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Gold;

    public Action OnWalletChange;

    public bool CanAfford(int amount) => (Gold >= amount);

    public void Spend(int amount)
    {
        if (CanAfford(amount))
        {
            Gold -= amount;
            OnWalletChange?.Invoke();
        }
    }

    public void Earn(int amount)
    {
        Gold += amount;
        OnWalletChange?.Invoke();
    }
}

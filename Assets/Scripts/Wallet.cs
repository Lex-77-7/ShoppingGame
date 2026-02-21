using System;
using UnityEngine;


public class Wallet : MonoBehaviour
{

    [SerializeField] private int gold;
    public int Gold => gold;

    public Action OnWalletChange;

    public bool CanAfford(int amount) => gold >= amount;

    private void Start()
    {
        OnWalletChange.Invoke();//set starting money in wallet UI
    }
    public void Spend(int amount)
    {
        if (!CanAfford(amount)) throw new InvalidOperationException("There is not enough gold in this wallet to perform this transaction");
        gold -= amount;
        OnWalletChange?.Invoke();

    }

    public void Earn(int amount)
    {
        gold += amount;
        OnWalletChange?.Invoke();
    }
}
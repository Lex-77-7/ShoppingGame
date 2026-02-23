using System;
using UnityEngine;

public class ShopTransactionHandler : MonoBehaviour
{
    public enum TransactionResult { Success, InsufficientFunds, InvalidItem }

    [Header("Inventories")]
    public Inventory PlayerInventory;
    public Inventory ShopInventory;

    [Header("UI References")]
    public InventoryUI PlayerInventoryUI;
    public InventoryUI ShopInventoryUI;

    [Header("Economy")]
    public Wallet PlayerWallet;

    [Header("UI Feedback events")]
    public Action<TransactionResult> OnTransactionComplete;

    private void OnEnable()
    {
        PlayerInventoryUI.OnSelectedSlotAction += HandleSell;
        ShopInventoryUI.OnSelectedSlotAction += HandleBuy;
    }

    private void OnDisable()
    {
        PlayerInventoryUI.OnSelectedSlotAction -= HandleSell;
        ShopInventoryUI.OnSelectedSlotAction -= HandleBuy;
    }

    private void HandleBuy(ItemBase item)
    {
        if (item == null)
        {
            OnTransactionComplete?.Invoke(TransactionResult.InvalidItem);
            return;
        }
        if (!PlayerWallet.CanAfford(item.BuyPrice))
        {
            OnTransactionComplete?.Invoke(TransactionResult.InsufficientFunds);
            return;
        }

        PlayerWallet.Spend(item.BuyPrice);
        ShopInventory.RemoveItem(item);
        PlayerInventory.AddItem(item);
        OnTransactionComplete?.Invoke(TransactionResult.Success);
    }

    private void HandleSell(ItemBase item)
    {
        if (item == null)
        {
            OnTransactionComplete?.Invoke(TransactionResult.InvalidItem);
            return;
        }

        PlayerWallet.Earn(item.SellPrice);
        PlayerInventory.RemoveItem(item);
        ShopInventory.AddItem(item);
        OnTransactionComplete?.Invoke(TransactionResult.Success);
    }
}

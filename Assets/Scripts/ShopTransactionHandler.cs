using System;
using UnityEngine;

public class ShopTransactionHandler : MonoBehaviour
{
    [Header("Inventories")]
    public Inventory PlayerInventory;
    public Inventory ShopInventory;

    [Header("UI References")]
    public InventoryUI PlayerInventoryUI;
    public InventoryUI ShopInventoryUI;

    [Header("Economy")]
    public Wallet PlayerWallet;

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
        if ((item == null) || !PlayerWallet.CanAfford(item.Price)) return;

        PlayerWallet.Spend(item.Price);

        ShopInventory.RemoveItem(item);
        PlayerInventory.AddItem(item);
    }

    private void HandleSell(ItemBase item)
    {
        if (item == null) return;

        PlayerWallet.Earn(item.Price);

        PlayerInventory.RemoveItem(item);
        ShopInventory.AddItem(item);
    }
}

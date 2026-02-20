using UnityEngine;

public class ShopTransactionHandler : MonoBehaviour
{
    public enum TransactionType { Buy, Sell }

    [Header("Settings")]
    public TransactionType type;

    [Header("References")]
    public InventoryUI playerInventory;
    public InventoryUI shopInventory;

    public void Execute()
    {
        if (type == TransactionType.Sell)
        {
            HandleTransfer(playerInventory, shopInventory);
        }
        else
        {
            HandleTransfer(shopInventory, playerInventory);
        }
    }

    private void HandleTransfer(InventoryUI source, InventoryUI target)
    {
        if (source.GetSelectedSlot() is ItemSlotUI selectedSlot)
        {
            ItemBase item = selectedSlot.GetItem();

            if (type == TransactionType.Buy)
            {
                // if (Gold < item.Value) return;
                // Gold -= item.Value;
                target.Inventory.AddItem(item);
                source.Inventory.RemoveItem(item);
                Debug.Log($"Bought {item.Name}");
            }
            else
            {
                // Gold += item.Value;
                source.Inventory.AddItem(item);
                target.Inventory.RemoveItem(item);
                Debug.Log($"Sold {item.Name}");
            }

            // Clean up
            source.SetSelectedSlot(null);
        }
        else
        {
            Debug.Log($"Select an item in {(type == TransactionType.Sell ? "Player" : "Shop")} inventory first!");
        }
    }
}

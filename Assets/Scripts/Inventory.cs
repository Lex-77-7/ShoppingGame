using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName= "Inventory/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField]
    private List<ItemSlot> ItemSlots;
    public int Length => ItemSlots.Count;

    public Action OnInventoryChange;

    public void AddItem(ItemBase item)
    {
        if (ItemSlots == null) ItemSlots = new List<ItemSlot>();

        var slot = GetSlot(item);

        if ((slot != null) && (item.IsStackable))
        {
            slot.AddOne();
        }
        else
        {
            slot = new ItemSlot(item);
            ItemSlots.Add(slot);
        }

        OnInventoryChange?.Invoke();
    }

    public void RemoveItem(ItemBase item)
    {
        if (ItemSlots == null) return;

        var slot = GetSlot(item);

        if (slot != null)
        {
            slot.RemoveOne();
            if (slot.IsEmpty())
            {
                RemoveSlot(slot);
            }
        }
    }

    private void RemoveSlot(ItemSlot slot)
    {
        ItemSlots.Remove(slot);
    }

    private ItemSlot GetSlot(ItemBase item)
    {
        for (int i = 0; i < ItemSlots.Count; i++)
        {
            if (ItemSlots[i].HasItem(item))
            {
                return ItemSlots[i];
            }
        }

        return null;
    }

    public ItemSlot GetSlot(int i)
    {
        return ItemSlots[i];
    }
}

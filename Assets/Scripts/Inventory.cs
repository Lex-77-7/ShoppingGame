using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField]
    private List<ItemSlot> itemSlots;
    public int Length => itemSlots.Count;

    public Action OnInventoryChange;

    public void AddItem(ItemBase item)
    {
        if (itemSlots == null) itemSlots = new List<ItemSlot>();

        var slot = GetSlot(item);

        if ((slot != null) && item.IsStackable)
        {
            slot.AddOne();
        }
        else
        {
            slot = new ItemSlot(item);
            itemSlots.Add(slot);
        }

        OnInventoryChange?.Invoke();
    }

    public void RemoveItem(ItemBase item)
    {
        if (itemSlots == null) return;

        var slot = GetSlot(item);

        if (slot != null)
        {
            slot.RemoveOne();
            if (slot.IsEmpty())
            {
                RemoveSlot(slot);
            }
        }

        OnInventoryChange?.Invoke();
    }

    private void RemoveSlot(ItemSlot slot)
    {
        itemSlots.Remove(slot);
    }

    private ItemSlot GetSlot(ItemBase item)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].HasItem(item))
            {
                return itemSlots[i];
            }
        }

        return null;
    }

    public ItemSlot GetSlot(int i)
    {
        return itemSlots[i];
    }
}

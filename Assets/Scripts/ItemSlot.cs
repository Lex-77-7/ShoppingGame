using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    public ItemBase Item;
    public int Quantity;

    public ItemSlot(ItemBase item)
    {
        Item = item;
        Quantity = 1;
    }

    public bool HasItem(ItemBase item)
    {
        return (Item == item);
    }

    internal bool CanHold(ItemBase item)
    {
        if (Item.IsStackable) return (Item == item);
        return false;
    }

    internal void AddOne()
    {
        Quantity++;
    }

    internal void RemoveOne()
    {
        Quantity--;
    }

    public bool IsEmpty()
    {
        return (Quantity < 1);
    }
}

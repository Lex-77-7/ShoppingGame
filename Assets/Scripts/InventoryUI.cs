using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory Inventory;
    public ItemSlotUI SlotPrefab;

    private List<GameObject> itemSlots;
    private ItemSlotUI selectedSlot;
    public event Action<ItemBase> OnSelectedSlotAction; //Buy, sell, give... when it changes inventories

    private void Start()
    {
        FillInventoryUI(Inventory);
    }

    private void OnEnable()
    {
        Inventory.OnInventoryChange += UpdateInventoryUI;
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChange -= UpdateInventoryUI;
    }

    private void UpdateInventoryUI()
    {
        ClearInventoryUI();
        FillInventoryUI(Inventory);
    }

    private void ClearInventoryUI()
    {
        foreach (GameObject item in itemSlots)
        {
            if (item)
            {
                Destroy(item);
            }
        }

        itemSlots.Clear();
    }

    private void FillInventoryUI(Inventory inventory)
    {
        itemSlots ??= new List<GameObject>();

        if (itemSlots.Count > 0)
        {
            ClearInventoryUI();
        }

        for (int i = 0; i < inventory.Length; i++)
        {
            itemSlots.Add(AddSlot(inventory.GetSlot(i)));
        }
    }

    private GameObject AddSlot(ItemSlot itemSlot)
    {
        ItemSlotUI element = Instantiate(SlotPrefab, Vector3.zero, Quaternion.identity, transform);

        element.Initialize(itemSlot, this);

        return element.gameObject;
    }

    public void SetSelectedSlot(ItemSlotUI slot)
    {
        if (selectedSlot != null)
            selectedSlot.SetSelected(false);

        selectedSlot = slot;
        selectedSlot.SetSelected(true);
        Debug.Log("Selected Slot: " + slot.GetItem().Name);
    }

    public ItemSlotUI GetSelectedSlot()
    {
        return selectedSlot;
    }

    public void SubmitSelectedSlot()
    {
        if (selectedSlot == null) return;

        selectedSlot.SetSelected(false);
        OnSelectedSlotAction?.Invoke(selectedSlot.GetItem());
        selectedSlot = null;
    }

    public void UseItem(ItemBase item)
    {
        Inventory.RemoveItem(item);
    }
}

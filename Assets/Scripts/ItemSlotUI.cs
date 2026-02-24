using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Image Image;
    public Image SelectedOverlay;
    public TextMeshProUGUI QuantityText;

    private Canvas canvas;
    private Transform parentTransform;
    private ItemBase item;
    private InventoryUI inventory;

    public static event Action <ItemBase> OnItemClicked;

    public void Initialize(ItemSlot slot, InventoryUI inventory)
    {
        Image.sprite = slot.Item.Image;

        QuantityText.text = slot.Quantity.ToString();
        QuantityText.enabled = slot.Quantity > 1;

        item = slot.Item;
        this.inventory = inventory;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.SetSelectedSlot(this);
        OnItemClicked?.Invoke(item);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!canvas)
        {
            canvas = GetComponentInParent<Canvas>();
        }

        parentTransform = transform.parent;

        transform.SetParent(canvas.transform, true);

        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        List<RaycastResult> ray = new();
        EventSystem.current.RaycastAll(eventData, ray);

        InventoryUI targetInventory = null;

        foreach (RaycastResult res in ray)
        {
            InventoryUI found = res.gameObject.GetComponentInParent<InventoryUI>();

            if (found != null)
            {
                targetInventory = found;
                break;
            }
        }

        if (targetInventory != null && targetInventory != inventory)
        {
            inventory.SubmitSelectedSlot();
        }

        transform.SetParent(parentTransform.transform);
        transform.localPosition = Vector3.zero;
    }

    public ItemBase GetItem()
    {
        return item;
    }

    public void SetSelected(bool selected)
    {
        SelectedOverlay.enabled = selected;
    }
}

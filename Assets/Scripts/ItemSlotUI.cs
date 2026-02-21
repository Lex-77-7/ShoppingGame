using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
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
        Ray ray = Camera.main.ScreenPointToRay(Pointer.current.position.ReadValue());
        RaycastHit2D hitData = Physics2D.GetRayIntersection(ray);

        if (hitData)
        {
            Debug.Log("Drop over object: " + hitData.collider.gameObject.name);

            IConsume consumer = hitData.collider.gameObject.GetComponent<IConsume>();

            if ((consumer != null) && (item is Consummable))
            {
                (item as Consummable).ConsumeItem(consumer);
                inventory.UseItem(item);
            }
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

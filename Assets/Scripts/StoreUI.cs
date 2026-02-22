using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public TextMeshProUGUI title;
    public Image image;
    public TextMeshProUGUI description;
    public TextMeshProUGUI cost;

    private void OnEnable()
    {
        ItemSlotUI.OnItemClicked += SetShowCaseItem;
    }

    private void OnDisable()
    {
        ItemSlotUI.OnItemClicked -= SetShowCaseItem;
    }

    private void SetShowCaseItem(ItemBase item)
    {
        title.text = item.Name;
        image.sprite = item.Image;
        description.text = item.Description;
        cost.text = "Cost: " + item.BuyPrice; // TODO: find which inventory is it to put buy price OR sell price
    }
}

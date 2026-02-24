using TMPro;
using Unity.Multiplayer.PlayMode;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class StoreUI : MonoBehaviour
{
    public TextMeshProUGUI title;
    public Image image;
    public TextMeshProUGUI description;
    public TextMeshProUGUI cost;
    private ItemBase SelectedItem;

    private void OnEnable()
    {
        ItemSlotUI.OnItemClicked += SetShowCaseItem;
        Localizer.OnLanguageChange += LocalizeItem;
    }

    private void OnDisable()
    {
        ItemSlotUI.OnItemClicked -= SetShowCaseItem;
        Localizer.OnLanguageChange -= LocalizeItem;
    }

    private void LocalizeItem()
    {
        title.text = SelectedItem.GetName();
        description.text = SelectedItem.GetDescription();
    }

    private void SetShowCaseItem(ItemBase item)
    {
        SelectedItem = item;
        LocalizeItem();

        image.sprite = item.Image;
        cost.text = "Cost: " + item.BuyPrice; // TODO: find which inventory is it to put buy price OR sell price
    }
}

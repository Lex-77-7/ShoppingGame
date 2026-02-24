using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public Image Image;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Cost;
    public TextMeshProUGUI LifeRestore;

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
        Title.text = SelectedItem.GetName();
        Description.text = SelectedItem.GetDescription();
        Cost.text = SelectedItem.getPriceKey();
    }

    private void SetShowCaseItem(ItemBase item)
    {
        SelectedItem = item;
        LocalizeItem();

        Image.sprite = item.Image;

        if (item is Consummable consummable)
        {
            LifeRestore.text = "Life: +" + consummable.LifeRestore;
        } else
        {
            LifeRestore.text = "";
        }
    }
}

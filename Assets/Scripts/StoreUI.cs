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
        Cost.text = SelectedItem.GetPriceKey();

        if (SelectedItem is Consummable consummable)
        {
            LifeRestore.text = consummable.GetLifeRestoreKey() + consummable.LifeRestore;
        }
        else
        {
            LifeRestore.text = "";
        }
    }

    private void SetShowCaseItem(ItemBase item)
    {
        SelectedItem = item;
        LocalizeItem();

        Image.sprite = item.Image;
    }
}

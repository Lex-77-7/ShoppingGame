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

    private ItemBase selectedItem;

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
        if (selectedItem == null) return;

        Title.text = selectedItem.GetName();
        Description.text = selectedItem.GetDescription();
        Cost.text = selectedItem.GetPriceKey();

        if (selectedItem is Consummable consummable)
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
        selectedItem = item;

        Image.sprite = selectedItem.Image;
        LocalizeItem();
    }
}

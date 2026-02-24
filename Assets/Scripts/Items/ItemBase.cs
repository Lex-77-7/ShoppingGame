using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items/Generic")]
public class ItemBase : ScriptableObject
{
    public string NameKey;
    public string DescriptionKey;
    public Sprite Image;
    public bool IsStackable;
    public int Price;

    public string GetName()
    {
        return Localizer.GetText(NameKey);
    }

    public string GetDescription()
    {
        return Localizer.GetText(DescriptionKey);
    }
}

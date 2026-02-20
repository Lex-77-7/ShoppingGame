using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items/Generic")]
public class ItemBase : ScriptableObject
{
    public string Name;
    public string Description;
    public int Cost;
    public Sprite Image;
    public bool IsStackable;
}

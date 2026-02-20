using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items/Potion")]
public class ItemPotion : Consummable
{
    public int Health;

    public override void ConsumeItem()
    {
        // Use item
    }
}

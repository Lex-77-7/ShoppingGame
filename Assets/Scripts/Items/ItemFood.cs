using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items/Food")]
public class ItemFood : Consummable
{
    public int Energy;

    public override void ConsumeItem(IConsume consumer)
    {
        // Use item
    }
}

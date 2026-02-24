using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items/Food")]
public class ItemFood : Consummable
{
    public int Energy;

    public override bool ConsumeItem(IConsume consumer)
    {
        // Use item
        if (consumer == null) return false;
        consumer.Consume(this);
        return true;
    }
}

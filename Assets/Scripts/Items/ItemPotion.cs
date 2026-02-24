using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items/Potion")]
public class ItemPotion : Consummable
{
    public int Health;

    public override bool ConsumeItem(IConsume consumer)
    {
        if (consumer == null) return false;
        consumer.Consume(this);
        return true;
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items/Food")]
public class ItemFood : Consummable
{
    public int Energy;

    public override int LifeRestore => Energy;

    public override bool ConsumeItem(IConsume consumer)
    {
        if (consumer == null) return false;
        consumer.Consume(this);
        return true;
    }
}

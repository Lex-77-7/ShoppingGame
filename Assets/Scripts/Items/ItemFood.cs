using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items/Food")]
public class ItemFood : Consumable
{
    public int Energy;
    public override int LifeRestore => Energy;

    public override bool ConsumeItem(IConsume consumer)
    {
        if (consumer == null) return false;

        return consumer.Consume(this);
    }
}

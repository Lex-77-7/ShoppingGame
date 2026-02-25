using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items/Potion")]
public class ItemPotion : Consumable
{
    public int Health;
    public override int LifeRestore => Health;

    public override bool ConsumeItem(IConsume consumer)
    {
        if (consumer == null) return false;

        return consumer.Consume(this); ;
    }
}

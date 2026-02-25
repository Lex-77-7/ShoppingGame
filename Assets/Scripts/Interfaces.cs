public interface ICanBePicked
{
    void PickUp();
    ItemBase GetItem();
}

public interface IConsume
{
    bool Consume(Consummable item);
}

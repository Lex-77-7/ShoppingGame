public interface ICanBePicked
{
    void PickUp();
    ItemBase GetItem();
}

public interface IPickUp
{
    void PickUp(ICanBePicked item);
}

public interface IConsume
{
    bool Consume(Consummable item);
}

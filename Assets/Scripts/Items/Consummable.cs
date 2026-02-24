public abstract class Consummable : ItemBase
{
    public abstract int LifeRestore { get; }
    public abstract bool ConsumeItem(IConsume consumer);
}

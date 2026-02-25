public abstract class Consumable : ItemBase
{
    public abstract int LifeRestore { get; }

    public string LifeRestoreKey;

    public string GetLifeRestore()
    {
        return Localizer.GetText(LifeRestoreKey) + ": +" + LifeRestore;
    }

    public abstract bool ConsumeItem(IConsume consumer);
}

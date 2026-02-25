public abstract class Consummable : ItemBase
{
    public abstract int LifeRestore { get; }

    public string LifeRestoreKey;

    public string GetLifeRestoreKey()
    {
        return Localizer.GetText(LifeRestoreKey) + " ";
    }

    public abstract bool ConsumeItem(IConsume consumer);
}

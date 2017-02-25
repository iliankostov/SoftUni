namespace Observer.Contracts
{
    using Skyrim.Items;

    public interface IDragonDeathObserver
    {
        void Update(Weapon weapon);
    }
}
namespace MusicShopManager.Engine.Factories
{
    using MusicShop.Models;
    using Interfaces;
    using Interfaces.Engine;

    public class MusicShopFactory : IMusicShopFactory
    {
        public IMusicShop CreateMusicShop(string name)
        {
            return new MusicShop(name);
        }
    }
}
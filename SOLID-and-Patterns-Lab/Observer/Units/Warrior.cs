namespace Skyrim.Units
{
    using System;
    using System.Collections.Generic;
    using Observer.Contracts;
    using Skyrim.Items;

    public class Warrior : Unit, IDragonDeathObserver
    {
        public Warrior(string name, int attackPoints, int healthPoints) 
            : base(name, attackPoints, healthPoints)
        {
            this.Inventory = new List<Weapon>();
        }

        public IList<Weapon> Inventory { get; private set; }

        public void Update(Weapon weapon)
        {
            this.Inventory.Add(weapon);
            Console.WriteLine(weapon);
        }
    }
}

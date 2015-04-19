namespace RPG
{
    using System;

    using RPG.Characters;
    using Weapons;

    public class Program
    {
        static void Main()
        {
            var axe = new Axe();
            var sword = new Sword();

            Warrior axeWarrior = new Warrior(axe);
            Warrior swordWarrior = new Warrior(sword);
            Mage axeMage = new Mage(axe);
            Mage swordMage = new Mage(sword);

            Console.WriteLine(axeWarrior);
            Console.WriteLine(swordMage);
        }
    }
}

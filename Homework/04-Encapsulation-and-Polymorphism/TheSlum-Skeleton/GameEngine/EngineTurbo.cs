namespace TheSlum.GameEngine
{
    using System;
    using TheSlum.Models.Characters;
    using TheSlum.Models.Items;

    public class EngineTurbo : Engine
    {
        public EngineTurbo()
            : base()
        {
        }

        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "create":
                    CreateCharacter(inputParams);
                    break;

                case "add":
                    AddItem(inputParams);
                    break;
                default:
                    base.ExecuteCommand(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character newCharacter;
            switch (inputParams[1].ToLower())
            {
                case "warrior":
                    newCharacter = new Warrior(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]), 200, 100, 150, (Team)Enum.Parse(typeof(Team), inputParams[5], true), 2);
                    break;
                case "mage":
                    newCharacter = new Mage(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]), 150, 50, 300, (Team)Enum.Parse(typeof(Team), inputParams[5], true), 5);
                    break;
                case "healer":
                    newCharacter = new Healer(inputParams[2], int.Parse(inputParams[3]), int.Parse(inputParams[4]), 75, 50, 60, (Team)Enum.Parse(typeof(Team), inputParams[5], true), 6);
                    break;
                default:
                    break;
            }            
        }

        protected new void AddItem(string[] inputParams)
        {
            Character characterItem = GetCharacterById(inputParams[1]);
            Item itemToAdd;
            switch (inputParams[2].ToLower())
            {
                case "axe":
                    itemToAdd = new Axe(inputParams[3]);
                    characterItem.AddToInventory(itemToAdd);
                    break;
                case "shield":
                    itemToAdd = new Shield(inputParams[3]);
                    characterItem.AddToInventory(itemToAdd);
                    break;
                case "injection":
                    itemToAdd = new InjectionBonus(inputParams[3]);
                    characterItem.AddToInventory(itemToAdd);
                    break;
                case "pill":
                    itemToAdd = new PillBonus(inputParams[3]);
                    characterItem.AddToInventory(itemToAdd);
                    break;
                default:
                    break;
            }
        }
    }
}
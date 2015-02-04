namespace TheSlum
{
    using System;
    using GameEngine;
    using TheSlum.Models.Characters;
    using TheSlum.Models.Items;

    public class EngineTurbo : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    this.PrintCharactersStatus(this.characterList);
                    break;
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                default:
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            Team team = (Team)Enum.Parse(typeof(Team), inputParams[5]);

            switch (inputParams[1])
            {
                case "warrior":
                    characterList.Add(new Warrior(id, x, y, 200, 100, 150, team, 2));
                    break;
                case "mage":
                    characterList.Add(new Mage(id, x, y, 150, 50, 300, team, 5));
                    break;
                case "healer":
                    characterList.Add(new Healer(id, x, y, 75, 50, 60, team, 6));
                    break;
                default:
                    break;
            }
        }

        protected new void AddItem(string[] inputParams)
        {
            string recipientId = inputParams[1];
            string itemId = inputParams[3];

            foreach (var character in this.characterList)
            {
                if (character.Id == recipientId)
                {
                    switch (inputParams[2])
                    {
                        case "axe":
                            character.AddToInventory(new Axe(itemId));
                            break;
                        case "injection":
                            character.AddToInventory(new InjectionBonus(itemId));
                            break;
                        case "pill":
                            character.AddToInventory(new PillBonus(itemId));
                            break;
                        case "shield":
                            character.AddToInventory(new Shield(itemId));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
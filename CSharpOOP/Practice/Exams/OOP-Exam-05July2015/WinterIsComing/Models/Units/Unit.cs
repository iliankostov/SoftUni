namespace WinterIsComing.Models.Units
{
    using System.Text;

    using WinterIsComing.Contracts;

    public abstract class Unit : IUnit
    {
        protected Unit(int x, int y, string name, int range, int attackPoints, int healthPoints, int defensePoints, int energyPoints)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
            this.Range = range;
            this.AttackPoints = attackPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.EnergyPoints = energyPoints;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public string Name { get; private set; }

        public int Range { get; private set; }

        public int AttackPoints { get; set; }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public ICombatHandler CombatHandler { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(string.Format(">{0} - {1} at ({2},{3})", this.Name, this.GetType().Name, this.X, this.Y));
            if (this.HealthPoints > 0)
            {
                output.AppendLine(string.Format("-Health points = {0}", this.HealthPoints))
                    .AppendLine(string.Format("-Attack points = {0}", this.AttackPoints))
                    .AppendLine(string.Format("-Defense points = {0}", this.DefensePoints))
                    .AppendLine(string.Format("-Energy points = {0}", this.EnergyPoints))
                    .Append(string.Format("-Range = {0}", this.Range));
            }
            else
            {
                output.Append("(Dead)");
            }

            return output.ToString();
        }
    }
}

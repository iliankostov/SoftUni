namespace Models.Items
{
    using System.Collections.Generic;
    using System.Text;

    using Enumerables;

    internal class Game : Item
    {
        internal Game(
            string id,
            string title,
            decimal price,
            string genre,
            AgeRestriction ageRestriction = AgeRestriction.Minor)
            : base(id, title, price, genre)
        {
            this.AgeRestriction = ageRestriction;
        }

        internal Game(
            string id,
            string title,
            decimal price,
            IList<string> genres,
            AgeRestriction ageRestriction = AgeRestriction.Minor)
            : base(id, title, price, genres)
        {
            this.AgeRestriction = ageRestriction;
        }

        public AgeRestriction AgeRestriction { get; private set; }

        public override string ToString()
        {
            StringBuilder gameInfo = new StringBuilder(base.ToString());
            gameInfo.Append(string.Format("Age Restriction: {0}", this.AgeRestriction));
            return gameInfo.ToString();
        }
    }
}
namespace MultimediaShop.Models
{
    using System;
    using System.Collections.Generic;

    public class Game : Item
    {
        private AgeRestriction ageRestriction;
        
        public Game(string id, string title, decimal price, string genre, AgeRestriction ageRestriction = AgeRestriction.Minor)
            : base(id, title, price, genre)
        {
            this.ageRestriction = ageRestriction;
        }

        public Game(string id, string title, decimal price, List<string> genres, AgeRestriction ageRestriction = AgeRestriction.Minor)
            : base(id, title, price, genres)
        {
            this.ageRestriction = ageRestriction;
        }
    }
}
namespace MusicShop.Models
{
    using System;
    using MusicShopManager.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Articles;

    internal class MusicShop : IMusicShop
    {
        private string name;

        public MusicShop(string name)
        {
            this.Name = name;
            this.Articles = new List<IArticle>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Shop name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IList<IArticle> Articles
        {
            get;
            private set;
        }

        public void AddArticle(IArticle article)
        {
            this.Articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            this.Articles.Remove(article);
        }

        public string ListArticles()
        {
            StringBuilder musicShopString = new StringBuilder();
            musicShopString.AppendFormat("{0} {1} {0}", new string('=', 5), this.Name).AppendLine();
            if (!this.Articles.Any())
            {
                musicShopString.Append("The shop is empty. Come back soon.");
                return musicShopString.ToString();
            }

            var microphones = this.Articles.Where(a => a is Microphone);
            musicShopString.Append(this.PrintArticles(microphones, "Microphones"));

            var drumps = this.Articles.Where(a => a is Drums);
            musicShopString.Append(this.PrintArticles(drumps, "Drums"));

            var electricGuitars = this.Articles.Where(a => a is ElectricGuitar);
            musicShopString.Append(this.PrintArticles(electricGuitars, "Electric guitars"));

            var acousticGuitars = this.Articles.Where(a => a is AcousticGuitar);
            musicShopString.Append(this.PrintArticles(acousticGuitars, "Acoustic guitars"));

            var bassGuitars = this.Articles.Where(a => a is BassGuitar);
            musicShopString.Append(this.PrintArticles(bassGuitars, "Bass guitars"));

            return musicShopString.ToString();
        }

        private string PrintArticles(IEnumerable<IArticle> articles, string title)
        {
            if (!articles.Any())
            {
                return string.Empty;
            }

            StringBuilder articlesString = new StringBuilder();
            articles = articles.OrderBy(a => a.Make + " " + a.Model);
            articlesString.AppendFormat("{0} {1} {0}", new string('-', 5), title).AppendLine();
            foreach (var article in articles)
            {
                articlesString.AppendLine(article.ToString());
            }

            return articlesString.ToString();
        }
    }
}

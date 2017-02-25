namespace Models.Items
{
    using System.Collections.Generic;
    using System.Text;

    internal class Video : Item
    {
        internal Video(string id, string title, decimal price, int lengthInMinutes, string genre)
            : base(id, title, price, genre)
        {
            this.LengthInMinutes = lengthInMinutes;
        }

        internal Video(string id, string title, decimal price, int lengthInMinutes, IList<string> genres)
            : base(id, title, price, genres)
        {
            this.LengthInMinutes = lengthInMinutes;
        }

        public int LengthInMinutes { get; private set; }

        public override string ToString()
        {
            StringBuilder videoInfo = new StringBuilder(base.ToString());
            if (this.LengthInMinutes >= 0)
            {
                videoInfo.Append(string.Format("Length: {0}", this.LengthInMinutes));
            }
            else
            {
                videoInfo.Append(string.Format("Length: 0"));
            }

            return videoInfo.ToString();
        }
    }
}
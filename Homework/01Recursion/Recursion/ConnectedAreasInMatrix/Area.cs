namespace ConnectedAreasInMatrix
{
    using System;

    internal class Area : IComparable<Area>
    {
        public int Col { get; set; }

        public int Row { get; set; }

        public int Size { get; set; }

        public int CompareTo(Area other)
        {
            int result = other.Size.CompareTo(this.Size);

            if (result == 0)
            {
                result = this.Row.CompareTo(other.Row);
                if (result == 0)
                {
                    result = this.Col.CompareTo(other.Col);
                }
            }

            return result;
        }
    }
}
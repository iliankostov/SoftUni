namespace Estates.Data
{
    using Interfaces;

    internal abstract class Estate : IEstate
    {
        protected Estate()
        {   
        }

        protected Estate(string name, EstateType estateType, double area, string location, bool isFurnishered)
        {
            this.Name = name;
            this.Type = estateType;
            this.Area = area;
            this.Location = location;
            this.IsFurnished = isFurnishered;
        }

        public string Name
        {
            get;
            set;
        }

        public EstateType Type
        {
            get;
            set;
        }

        public double Area
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public bool IsFurnished
        {
            get;
            set;
        }

        public override string ToString()
        {
            string furnished = this.IsFurnished ? "Yes" : "No";
            return string.Format("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}", this.Type, this.Name, this.Area, this.Location, furnished);
        }
    }
}
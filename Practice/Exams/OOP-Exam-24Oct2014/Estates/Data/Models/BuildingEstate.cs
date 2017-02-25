namespace Estates.Data.Models
{
    using System;
    using Interfaces;

    internal abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private int rooms;

        public bool HasElevator
        {
            get;
            set;
        }

        public int Rooms
        {
            get
            {
                return this.rooms;
            }

            set
            {
                if (value < 0)
                {
                    throw new Exception("Rooms cannot be negative.");
                }

                this.rooms = value;
            }
        }

        public override string ToString()
        {
            string elevator = this.HasElevator ? "Yes" : "No";
            return base.ToString() + string.Format(", Rooms: {0}, Elevator: {1}", this.Rooms, elevator);
        }
    }
}
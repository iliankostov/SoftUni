namespace ParkSystem
{
    using System;

    public class Layout
    {
        private int sectors;

        private int placesBySectors;

        public Layout(int numberOfSectors, int placesPerSector)
        {
            this.Sectors = numberOfSectors;
            this.PlacesBySectors = placesPerSector;
        }

        public int Sectors
        {
            get
            {
                return this.sectors;
            }

            set
            {
                if (value <= 0)
                {
                    throw new DivideByZeroException("The number of sectors must be positive.");
                }

                this.sectors = value;
            }
        }

        public int PlacesBySectors
        {
            get
            {
                return this.placesBySectors;
            }

            set
            {
                if (value <= 0)
                {
                    throw new DivideByZeroException("The number of places per sector must be positive.");
                }

                this.placesBySectors = value;
            }
        }

        public int GetSectors()
        {
            return this.sectors;
        }

        public int GetPlacesBySectors()
        {
            return this.placesBySectors;
        }
    }
}
namespace GalacticGPS
{
    internal struct Location
    {
        public Location(double latitude, double longtitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longtitude;
            this.Planet = planet;
        }

        public Planet Planet { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} - {2}", this.Latitude, this.Longitude, this.Planet);
        }
    }
}

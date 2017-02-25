namespace ParkSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Wintellect.PowerCollections;

    public class DataRepository
    {
        public DataRepository(int numberOfSectors)
        {
            this.Cars = new Dictionary<IVehicle, string>();
            this.Park = new Dictionary<string, IVehicle>();
            this.LicensePlate = new Dictionary<string, IVehicle>();
            this.Dates = new Dictionary<IVehicle, DateTime>();
            this.Owners = new MultiDictionary<string, IVehicle>(false);
            this.Count = new int[numberOfSectors];
        }

        public Dictionary<IVehicle, string> Cars { get; set; }

        public Dictionary<string, IVehicle> Park { get; set; }

        public Dictionary<string, IVehicle> LicensePlate { get; set; }

        public Dictionary<IVehicle, DateTime> Dates { get; set; }

        public MultiDictionary<string, IVehicle> Owners { get; set; }

        public int[] Count { get; set; }
    }
}
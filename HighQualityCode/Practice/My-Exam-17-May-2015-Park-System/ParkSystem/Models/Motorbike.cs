namespace ParkSystem.Models
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using Contracts;

    public class Motorbike : IVehicle
    {
        private string licensePlate; 
        private string owner; 
        private decimal regularrate; 
        private decimal morerate; 
        private int hh;

        public Motorbike(string licensePlate, string owner, int reservedHours)
        {
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.ReservedHours = reservedHours;
            this.RegularRate = (decimal)1.35;
            this.OvertimeRate = 3M;
        }

        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }

            set
            {
                if (Regex.IsMatch(value, @"^[A-Z]{1}\d{3}[A-Z]{2,}$"))
                {
                    throw new ArgumentException("The license plate number is invalid.");
                }

                this.licensePlate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                if (value == null && value == string.Empty)
                {
                    throw new InvalidCastException("The owner is required.");
                }

                this.owner = value;
            }
        }

        public decimal RegularRate
        {
            get
            {
                return this.regularrate;
            }

            set
            {
                if (value < 0)
                {
                    throw new InvalidTimeZoneException(string.Format("The regular rate must be non-negative."));
                }

                this.regularrate = value;
            }
        }

        public decimal OvertimeRate
        {
            get
            {
                return this.morerate;
            }

            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException(string.Format("The overtime rate must be non-negative."));
                }

                this.morerate = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                return this.hh;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                this.hh = value;
            }
        }

        public override string ToString()
        {
            var vehicle = new StringBuilder();
            vehicle.AppendFormat("{0} [{1}], owned by {2}", GetType().Name, this.LicensePlate, this.Owner); 
            return vehicle.ToString();
        }
    }
}
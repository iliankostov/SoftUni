namespace ParkSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class VehiclePark : IVehiclePark
    {
        private Layout layout;

        private DataRepository data;

        public VehiclePark(int numberOfSectors, int placesPerSector)
        {
            this.layout = new Layout(numberOfSectors, placesPerSector);
            this.data = new DataRepository(numberOfSectors);
        }

        public string InsertCar(Car car, int sector, int place, DateTime startTime)
        {
            if (sector > this.layout.GetSectors())
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.layout.GetPlacesBySectors())
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.data.Park.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.data.LicensePlate.ContainsKey(car.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", car.LicensePlate);
            }

            this.data.Cars[car] = string.Format("({0},{1})", sector, place);
            this.data.Park[string.Format("({0},{1})", sector, place)] = car;
            this.data.LicensePlate[car.LicensePlate] = car;
            this.data.Dates[car] = startTime;
            this.data.Owners[car.Owner].Add(car);
            this.data.Count[sector - 1]++;

            return string.Format("{0} parked successfully at place ({1},{2})", car.GetType().Name, sector, place);
        }

        public string InsertMotorbike(Motorbike motorbike, int sector, int place, DateTime startTime)
        {
            if (sector > this.layout.GetSectors())
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.layout.GetPlacesBySectors())
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.data.Park.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.data.LicensePlate.ContainsKey(motorbike.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", motorbike.LicensePlate);
            }

            this.data.Cars[motorbike] = string.Format("({0},{1})", sector, place);
            this.data.Park[string.Format("({0},{1})", sector, place)] = motorbike;
            this.data.LicensePlate[motorbike.LicensePlate] = motorbike;
            this.data.Dates[motorbike] = startTime;
            this.data.Owners[motorbike.Owner].Add(motorbike);
            this.data.Count[sector - 1]++;

            return string.Format("{0} parked successfully at place ({1},{2})", motorbike.GetType().Name, sector, place);
        }

        public string InsertTruck(Truck truck, int sector, int place, DateTime dateTime)
        {
            if (sector > this.layout.GetSectors())
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.layout.GetPlacesBySectors())
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.data.Park.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.data.LicensePlate.ContainsKey(truck.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", truck.LicensePlate);
            }

            this.data.Cars[truck] = string.Format("({0},{1})", sector, place);
            this.data.Park[string.Format("({0},{1})", sector, place)] = truck;
            this.data.LicensePlate[truck.LicensePlate] = truck;
            this.data.Dates[truck] = dateTime;
            this.data.Owners[truck.Owner].Add(truck);
            this.data.Count[sector - 1]++;

            return string.Format("{0} parked successfully at place ({1},{2})", truck.GetType().Name, sector, place);
        }

        public string ExitVehicle(string licensePlate, DateTime endTime, decimal money)
        {
            var vehicle = this.data.LicensePlate.ContainsKey(licensePlate) ? this.data.LicensePlate[licensePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            var start = this.data.Dates[vehicle];
            int endd = (int)Math.Round((endTime - start).TotalHours);
            var ticket = new StringBuilder();
            ticket
                .AppendLine(new string('*', 20))
                .AppendFormat("{0}", vehicle.ToString())
                .AppendLine()
                .AppendFormat("at place {0}", this.data.Cars[vehicle])
                .AppendLine()
                .AppendFormat("Rate: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate)
                .AppendLine()
                .AppendFormat("Overtime rate: ${0:F2}", endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)
                .AppendLine()
                .AppendLine(new string('-', 20))
                .AppendFormat("Total: ${0:F2}", (vehicle.ReservedHours * vehicle.RegularRate) + (endd > vehicle.ReservedHours ? ((endd - vehicle.ReservedHours) * vehicle.OvertimeRate) : 0))
                .AppendLine()
                .AppendFormat("Paid: ${0:F2}", money)
                .AppendLine()
                .AppendFormat("Change: ${0:F2}", money - ((vehicle.ReservedHours * vehicle.RegularRate) + (endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)))
                .AppendLine()
                .Append(new string('*', 20));

            int sector = int.Parse(this.data.Cars[vehicle].Split(new[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            this.data.Park.Remove(this.data.Cars[vehicle]);
            this.data.Cars.Remove(vehicle);
            this.data.LicensePlate.Remove(vehicle.LicensePlate);
            this.data.Dates.Remove(vehicle);
            this.data.Owners.Remove(vehicle.Owner, vehicle);
            this.data.Count[sector - 1]--;

            return ticket.ToString();
        }

        public string GetStatus()
        {
            var places = this.data.Count.Select((sssss, iiiii) => string.Format("Sector {0}: {1} / {2} ({3}% full)", iiiii + 1, sssss, this.layout.GetPlacesBySectors(), Math.Round((double)sssss / this.layout.GetPlacesBySectors() * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licensePlate)
        {
            var vehicle = this.data.LicensePlate.ContainsKey(licensePlate) ? this.data.LicensePlate[licensePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            return this.Input(new[] { vehicle });
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (!this.data.Park.Values.Where(v => v.Owner == owner).Any())
            {
                return string.Format("No vehicles by {0}", owner);
            }

            var found = this.data.Park.Values.ToList();
            var res = found;

            foreach (var f in found)
            {
                res = res.Where(v => v.Owner == owner).ToList();
            }

            return string.Join(Environment.NewLine, this.Input(res));
        }

        private string Input(IEnumerable<IVehicle> carros)
        {
            return string.Join(Environment.NewLine, carros.Select(vehicle => string.Format("{0}{1}Parked at {2}", vehicle.ToString(), Environment.NewLine, this.data.Cars[vehicle])));
        }
    }
}
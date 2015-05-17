namespace ParkSystem
{
    using System;

    public class ProcessCommand
    {
        public VehiclePark VehiclePark { get; set; }

        public string Output(ICommand command)
        {
            if (command.Name == "SetupPark")
            {
                VehiclePark = new VehiclePark(int.Parse(command.Parameters["sectors"]), int.Parse(command.Parameters["placesPerSector"]));
                return "Vehicle park created";
            }

            if (command.Name != "SetupPark" && VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }

            string output;

            switch (command.Name)
            {
                case "Park":

                    switch (command.Parameters["type"])
                    {
                        case "car":
                            output = VehiclePark.InsertCar(
                                new Car(
                                    command.Parameters["licensePlate"],
                                    command.Parameters["owner"],
                                    int.Parse(command.Parameters["hours"])),
                                    int.Parse(command.Parameters["sector"]),
                                    int.Parse(command.Parameters["place"]),
                                    DateTime.Parse(command.Parameters["time"], null, System.Globalization.DateTimeStyles.RoundtripKind));
                            break;
                        case "motorbike":
                            output = VehiclePark.InsertMotorbike(
                                new Motorbike(
                                        command.Parameters["licensePlate"],
                                        command.Parameters["owner"],
                                        int.Parse(command.Parameters["hours"])),
                                        int.Parse(command.Parameters["sector"]),
                                        int.Parse(command.Parameters["place"]),
                                        DateTime.Parse(command.Parameters["time"], null, System.Globalization.DateTimeStyles.RoundtripKind));
                            break;
                        case "truck":
                            output = VehiclePark.InsertTruck(
                                new Truck(
                                    command.Parameters["licensePlate"],
                                    command.Parameters["owner"],
                                    int.Parse(command.Parameters["hours"])),
                                    int.Parse(command.Parameters["sector"]),
                                    int.Parse(command.Parameters["place"]),
                                    DateTime.Parse(command.Parameters["time"], null, System.Globalization.DateTimeStyles.RoundtripKind));
                            break;
                        default:
                            throw new IndexOutOfRangeException("Invalid command.");
                    }

                    break;
                case "Exit":
                    output = VehiclePark.ExitVehicle(
                        command.Parameters["licensePlate"], 
                        DateTime.Parse(command.Parameters["time"], null, System.Globalization.DateTimeStyles.RoundtripKind), 
                        decimal.Parse(command.Parameters["paid"]));
                    break;
                case "Status":
                    output = VehiclePark.GetStatus();
                    break;
                case "FindVehicle":
                    output = VehiclePark.FindVehicle(command.Parameters["licensePlate"]);
                    break;
                case "VehiclesByOwner":
                    output = VehiclePark.FindVehiclesByOwner(command.Parameters["owner"]);
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid command.");
            }

            return output;
        }
    }
}

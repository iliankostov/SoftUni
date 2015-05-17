namespace ParkSystem
{
    using System;

    /// <summary>
    /// Defines a park holding vehicles (Car, Motorbike and Truck vehicles)
    /// and a set of commands to insert / exit / find vehicles.
    /// </summary>
    public interface IVehiclePark
    {
        /// <summary>
        /// Insert a car to the park with given car information, parking sector, place in the sector, and start time
        /// </summary>
        /// <param name="car">car information</param>
        /// <param name="sector">parking sector</param>
        /// <param name="placeNumber">place in the sector</param>
        /// <param name="startTime">start time</param>
        /// <returns>A message if the car is parked or error if cannot be parked</returns>
        string InsertCar(Car car, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Insert a motorbike to the park with given motorbike information, parking sector, place in the sector, and start time
        /// </summary>
        /// <param name="motorbike">motorbike information</param>
        /// <param name="sector">parking sector</param>
        /// <param name="placeNumber">place in the sector</param>
        /// <param name="startTime">start time</param>
        /// <returns>A message if the motorbike is parked or error if cannot be parked</returns>
        string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        ///  Insert a truck to the park with given truck information, parking sector, place in the sector, and start time
        /// </summary>
        /// <param name="truck">truck information</param>
        /// <param name="sector">parking sector</param>
        /// <param name="placeNumber">place in the sector</param>
        /// <param name="startTime">start time</param>
        /// <returns>A message if the truck is parked or error if cannot be parked</returns>
        string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Exit vehicle from the park by givven license plate, end time and givven amount paid
        /// </summary>
        /// <param name="licensePlate">license plate</param>
        /// <param name="endTime">end time</param>
        /// <param name="amountPaid">amount paid</param>
        /// <returns>A message if the vehicle exit the park with a ticket and cash back</returns>   
        string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);

        /// <summary>
        /// Get the status of the park with sectors, places by sectors and full percentage
        /// </summary>
        /// <returns>A message with the number of sectors, places by sectors and full percentage</returns>
        string GetStatus();

        /// <summary>
        /// Find vehicle by givven license plate
        /// </summary>
        /// <param name="licensePlate">license plate</param>
        /// <returns>A message with found vehicle, its license number, owner and parking place</returns>
        string FindVehicle(string licensePlate);

        /// <summary>
        /// Find vehicles by owner
        /// </summary>
        /// <param name="owner">owner</param>
        /// <returns>A message with all the vehicles of the givven owner</returns>
        string FindVehiclesByOwner(string owner);
    }
}
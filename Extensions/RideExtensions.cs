using GreenBridgeWebApi.Models;

namespace GreenBridgeWebApi.Extensions
{
    public static class RideExtensions
    {
        public static void Map(this Ride dbRide, Ride ride)
        {
            dbRide.Car = ride.Car;
            dbRide.CarId = ride.CarId;
            dbRide.DateTime = ride.DateTime;
            dbRide.StartLocation = ride.StartLocation;
            dbRide.Destination = ride.Destination;
            dbRide.FreeSeats = ride.FreeSeats;
        }
    }
}
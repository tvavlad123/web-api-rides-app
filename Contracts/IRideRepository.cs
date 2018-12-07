using System.Collections.Generic;
using GreenBridgeWebApi.Models;

namespace GreenBridgeWebApi.Contracts
{
    public interface IRideRepository : IRepositoryBase<Ride>
    {
        IEnumerable<Ride> GetAllRides();
        Ride GetRideById(int rideId);

        void Delete(int rideId);

        void CreateRide(Ride ride);
        void UpdateRide(Ride dbRide, Ride ride);

    }

}
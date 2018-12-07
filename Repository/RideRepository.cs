using System.Collections.Generic;
using System.Linq;
using GreenBridgeWebApi.Contracts;
using GreenBridgeWebApi.Extensions;
using GreenBridgeWebApi.Models;
using Repository;

namespace GreenBridgeWebApi.Repository
{
    public class RideRepository : RepositoryBase<Ride>, IRideRepository
    {
        public RideRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }


        public IEnumerable<Ride> GetAllRides()
        {
            return FindAll()
                .OrderBy(ri => ri.StartLocation);
        }

        public Ride GetRideById(int rideId)
        {
            return FindByCondition(ride => ride.RideId.Equals(rideId))
                    .DefaultIfEmpty(new Ride())
                    .FirstOrDefault();
        }

        public void Delete(int rideId)
        {
            var target = FindByCondition(ride => ride.RideId.Equals(rideId)).FirstOrDefault();
            Delete(target);
        }
        public void CreateRide(Ride ride)
        {
            Create(ride);
            Save();
        }

        public void UpdateRide(Ride dbRide, Ride ride)
        {
            dbRide.Map(ride);
            Update(dbRide);
            Save();
        }
    }
}